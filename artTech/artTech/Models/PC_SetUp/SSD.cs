using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class SSD
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }//
        public string SSD_FormFactor { get; set; } = null!;
        public string SSD_Size { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
    }
}
