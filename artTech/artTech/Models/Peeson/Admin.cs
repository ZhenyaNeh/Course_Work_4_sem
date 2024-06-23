using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models.Peeson
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<PC> PublishPC { get; set; }
        public List<User> Users { get; set; }


        public Admin() { }

        public Admin(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
