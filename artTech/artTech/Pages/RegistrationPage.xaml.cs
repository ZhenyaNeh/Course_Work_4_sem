using artTech.Commands;
using artTech.Controll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace artTech.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var (valid, error) = Account_Control.VeritifyRegistration(Login.Text, Email.Text, Password.Password, RepitPassword.Password);

            if (!valid )
            {
                switch (error)
                {
                    case (int)EnumConfig.ErrorType.Name:
                        Login.Foreground = Brushes.PaleVioletRed;
                        Email.Foreground = Brushes.Black;
                        Password.Foreground = Brushes.Black;
                        RepitPassword.Foreground = Brushes.Black;

                        break;
                    case (int)EnumConfig.ErrorType.Email:
                        Login.Foreground = Brushes.Black;
                        Email.Foreground = Brushes.PaleVioletRed;
                        Password.Foreground = Brushes.Black;
                        RepitPassword.Foreground = Brushes.Black;

                        break;
                    case (int)EnumConfig.ErrorType.Password:
                        Login.Foreground = Brushes.Black;
                        Email.Foreground = Brushes.Black;
                        Password.Foreground = Brushes.PaleVioletRed;
                        RepitPassword.Foreground = Brushes.PaleVioletRed;

                        break;
                    case (int)EnumConfig.ErrorType.EmptyField:
                        Login.Foreground = Brushes.PaleVioletRed;
                        Email.Foreground = Brushes.PaleVioletRed;
                        Password.Foreground = Brushes.PaleVioletRed;
                        RepitPassword.Foreground = Brushes.PaleVioletRed;

                        break;
                    default:
                        Login.Foreground = Brushes.PaleVioletRed;
                        Email.Foreground = Brushes.Black;
                        Password.Foreground = Brushes.Black;
                        RepitPassword.Foreground = Brushes.Black;

                        break;
                }
            }
        }



        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            Login.Foreground = Brushes.Black;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email.Foreground = Brushes.Black;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Foreground = Brushes.Black;
        }

        private void RepitPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            RepitPassword.Foreground = Brushes.Black;
        }
    }
}
