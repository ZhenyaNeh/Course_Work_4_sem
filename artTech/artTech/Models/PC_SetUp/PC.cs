using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class PC
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public CPU CPU { get; set; }
        public GPU GPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public SSD SSD { get; set; }
        public CoolingSystem CoolingSystem { get; set; }
        public PowerUnit PowerUnit { get; set; }
        public ComputerCase ComputerCase { get; set; }
        public int? UserId { get; set; }
        public int? AdminId { get; set; }

        public PC() { }

        
        public PC(CPU cPU, GPU gPU, Motherboard motherboard, RAM rAM, SSD sSD, CoolingSystem coolingSystem, PowerUnit powerUnit, ComputerCase computerCase)
        {
            this.CPU = cPU;
            this.GPU = gPU;
            this.Motherboard = motherboard;
            this.RAM = rAM;
            this.SSD = sSD;
            this.CoolingSystem = coolingSystem;
            this.PowerUnit = powerUnit;
            this.ComputerCase = computerCase;
        }
    }
}
