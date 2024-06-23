using artTech.Models;
using artTech.Models.Peeson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Data
{
    public class ConfigPCContext: DbContext
    {
        public DbSet<CPU> CPUs { get; set; } 
        public DbSet<GPU> GPUs { get; set; } 
        public DbSet<Motherboard> Motherboards{ get; set; } 
        public DbSet<RAM> RAMs { get; set; } 
        public DbSet<SSD> SSDs { get; set; } 
        public DbSet<CoolingSystem> CoolingSystems { get; set; } 
        public DbSet<PowerUnit> PowerUnits { get; set; } 
        public DbSet<ComputerCase> ComputerCases { get; set; } 
        public DbSet<PC> PCs { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        }

    }
}
