using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class CPU
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }//
        public string CPU_Manufacturer { get; set; } = null!;
        public string CPU_Socket { get; set; } = null!;
        public string CPU_MemorySupport { get; set; } = null!;
        public string CPU_IntegratedGraphics { get; set; }//<-------------------------------
        public int CPU_TDP { get; set; }
        public List<Comment> Comments { get; set; } = null!;


        public CPU() { }

        public CPU(int id, string name, decimal price) 
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public CPU(int id, string cPU_Manufacturer, string name, string image, decimal price, string cPU_Socket, string cPU_MemorySupport, string cPU_IntegratedGraphics, int cPU_TDP)
        {
            Id = id;
            CPU_Manufacturer = cPU_Manufacturer;
            Name = name;
            Image = image;
            Price = price;
            CPU_Socket = cPU_Socket;
            CPU_MemorySupport = cPU_MemorySupport;
            CPU_IntegratedGraphics = cPU_IntegratedGraphics;
            CPU_TDP = cPU_TDP;
        }
    }
}
