using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models.Peeson
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<PC> SaveConfig { get; set; } = null!;
        public int? AdminId { get; set; }
        


        public User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public User(string name, string email, string password, List<PC> saveConfig)
        {
            Name = name;
            Email = email;
            Password = password;
            SaveConfig = saveConfig;
        }
    }
}
