using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//
        public string Image { get; set; } = null!;//

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }//
        //
        //-CPU_Support
        //
        public string Motherboard_CPU_Spport { get; set; } = null!; //amd or intel
        public string Motherboard_Socket { get; set; } = null!;
        //
        //-Motherboard_FormFactor 
        //
        public string Motherboard_FormFactor { get; set; } = null!;
        //
        //-RAM_Support
        //
        public string Motherboard_MemorySupport { get; set; } = null!;
        public int Motherboard_NumberOf_RAM_Slots { get; set; }
        public int Motherboard_Maximum_RAM_Capacity { get; set; }
        public int Motherboard_Maximum_RAM_Frequency { get; set; }
        //
        //-SSD_Support
        //
        public int Motherboard_NumberOf_M2_Slots { get; set; }
        public int Motherboard_NumberOf_SATA3_Slots { get; set; }

        public List<Comment> Comments { get; set; } = null!;
    }
}
