using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Commands
{
    public class EnumConfig
    {
        public enum Components
        {
            CPU,
            GPU,
            MotherBoard,
            RAM,
            SSD,
            CoolingSystem,
            PowerUnit,
            ComputerCase,
            PC
        }

        public enum ErrorType
        {
            Name,
            Email,
            Password,
            EmptyField
        }
    }
}
