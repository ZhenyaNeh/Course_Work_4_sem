using artTech.Data;
using artTech.Models;
using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace artTech.Controll
{
    public static class Account_Control
    {
        private static MyRepository<User> userRepositoty = new MyRepository<User>(new ConfigPCContext());
        //private static MyRepository<Admin> adminRepositoty = new MyRepository<Admin>(new ConfigPCContext());

        public static List<User> Users {  get; set; }
        public static List<Admin> Admins { get; set;}

        public static event EventHandler LoadHomePage;

        public static bool CurrentUserIsAdmin { get; set; } = false;
        public static bool CurrentUserSignIn { get; set; } = false;

        public static User CurrentUser { get; set; }
        public static Admin CurrentAdmin { get; set; }

        private static string EmailPattern { get; set; } = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        static Account_Control()
        {
            Users = new List<User>();
            Admins = new List<Admin>();
        }

        public static void UpdateInformation()
        {
            using (var context = new ConfigPCContext())
            {
                Users = context.Users.ToList();
                Admins = context.Admins.ToList();
            }
        }

        public static void SignOut()
        {
            CurrentUserSignIn = false;
            CurrentUserIsAdmin = false;
            CurrentAdmin = new Admin();
            CurrentUser = new User();
        }

        private static void RegistrationNewUser(string login, string email, string password)
        {
            User user = new User(login, email, password);
            //Admin admin = new Admin();
            using (var context = new ConfigPCContext())
            {
                //adminRepositoty.Create(new Admin(login, password));
                userRepositoty.Create(user);
            }

            CurrentUserSignIn = true;
            CurrentUserIsAdmin = false;
            CurrentUser = user;
            if(CurrentUser.SaveConfig == null)
            {
                CurrentUser.SaveConfig = new List<PC>();
            }

            UpdateInformation();
            LoadHomePage.Invoke(CurrentUserSignIn, EventArgs.Empty);
        }

        public static bool VeritifyLogIn(string login, string password)
        {
            foreach(var user in Users)
            {
                if(user.Name == login)
                {
                    if (user.Password == password)
                    {
                        CurrentUserSignIn = true;
                        CurrentUserIsAdmin = false;
                        CurrentUser = user;
                        if (CurrentUser.SaveConfig == null)
                        {
                            CurrentUser.SaveConfig = new List<PC>();
                        }

                        LoadHomePage.Invoke(CurrentUserSignIn, EventArgs.Empty);
                        return true;
                    }
                }
            }


            foreach (var admin in Admins)
            {
                if (admin.Name == login)
                {
                    if (admin.Password == password)
                    {
                        CurrentUserSignIn = true;
                        CurrentUserIsAdmin = true;
                        CurrentAdmin = admin;

                        if (CurrentAdmin.PublishPC == null)
                        {
                            CurrentAdmin.PublishPC = new List<PC>();
                        }
                        LoadHomePage.Invoke(CurrentUserSignIn, EventArgs.Empty);
                        return true;
                    }
                }
            }

            return false;
        }

        public static (bool, int) VeritifyRegistration(string login, string email, string password, string repitPassword)
        {
            if (login == "" && email == "" && password == "" && repitPassword == "")
                return (false, 3/*"Uncorrect Password"*/);

            if (password != repitPassword)
                return (false, 2/*"Uncorrect Password"*/);

            if (login.ToLower().Contains("admin"))
                return (false, 0/*"Uncorrect Name"*/);

            if (!Regex.IsMatch(email, EmailPattern))
                return (false, 1/*"Uncorrect Email"*/);

            foreach (var user in Users)
            {
                if (user.Name == login)
                {
                    return (false, 0/*"A user with this login and email address already exists"*/);
                }
                if (user.Email == email)
                    {
                        return (false, 1/*"A user with this login and email address already exists"*/);
                    }
            }

            RegistrationNewUser(login, email, password);
            return (true, 4/*"Correct"*/);
        }
    }
}
