using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class GPU
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }//
        public string GPU_Manufacturer { get; set; } = null!;
        public string GPU_MemorySupport { get; set; } = null!;
        public int GPU_RecommendedPowerSupply { get; set; }

        public List<Comment> Comments { get; set; } = null!;

        public GPU() { }

        public GPU(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
