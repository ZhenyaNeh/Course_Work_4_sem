using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class RAM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }//
        public string RAM_MemoryType { get; set; } = null!;//type
        public int RAM_CountOfSticks { get; set; }
        public int RAM_OverallVolume {  get; set; }// count ram
        public int RAM_Frequency {  get; set; }//max freq...
        public List<Comment> Comments { get; set; } = null!;
    }
}
