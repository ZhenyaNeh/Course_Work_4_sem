using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models.Peeson
{
    public class Comment
    {
        public int Id { get; set; }
        public string NamePerson { get; set; } = null!;
        public string CommentString { get; set; } = null!;

        public int? CPUId { get; set; }
        public int? GPUId { get; set; }
        public int? ComputerCaseId { get; set; }
        public int? CoolingSystemId { get; set; }
        public int? MotherboardId { get; set; }
        public int? RAMId { get; set; }
        public int? SSDId { get; set; }
        public int? PowerUnitId { get; set; }
    }
}
