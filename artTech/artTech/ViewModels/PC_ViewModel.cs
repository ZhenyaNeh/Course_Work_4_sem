using artTech.Models.Specification;
using artTech.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artTech.Data;
using artTech.Models.Peeson;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace artTech.ViewModels
{
    public class PC_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Specification> _ShortSpecification;
        private readonly ObservableCollection<Specification> _CPU;
        private readonly ObservableCollection<Specification> _GPU;
        private readonly ObservableCollection<Specification> _Motherboard;
        private readonly ObservableCollection<Specification> _RAM;
        private readonly ObservableCollection<Specification> _SSD;
        private readonly ObservableCollection<Specification> _CoolingSystem;
        private readonly ObservableCollection<Specification> _PowerUnit;
        private readonly ObservableCollection<Specification> _ComputerCase;

        public IEnumerable<Specification> ShortSpecifications => _ShortSpecification;
        public IEnumerable<Specification> CPUs => _CPU;
        public IEnumerable<Specification> GPUs => _GPU;
        public IEnumerable<Specification> Motherboards => _Motherboard;
        public IEnumerable<Specification> RAMs => _RAM;
        public IEnumerable<Specification> SSDs => _SSD;
        public IEnumerable<Specification> CoolingSystems => _CoolingSystem;
        public IEnumerable<Specification> PowerUnits => _PowerUnit;
        public IEnumerable<Specification> ComputerCases => _ComputerCase;

        public PC_ViewModel(PC pc)
        {
            _ShortSpecification = new ObservableCollection<Specification>()
            {
                new Specification("CPU", pc.CPU.Name),
                new Specification("GPU", pc.GPU.Name),
                new Specification("Motherboard", pc.Motherboard.Name),
                new Specification("RAM", pc.RAM.Name),
                new Specification("SSD", pc.SSD.Name),
                new Specification("CoolingSystem", pc.CoolingSystem.Name),
                new Specification("PowerUnit", pc.PowerUnit.Name),
                new Specification("ComputerCase", pc.ComputerCase.Name),
            };

            _CPU = new ObservableCollection<Specification>()
            {
                new("Manufacturer", pc.CPU.CPU_Manufacturer),
                new("Socket", pc.CPU.CPU_Socket),
                new("Memory Support", pc.CPU.CPU_MemorySupport),
                new("Integrated Graphics", pc.CPU.CPU_IntegratedGraphics),
                new("TDP", pc.CPU.CPU_TDP.ToString()+"W"),
            };

            _GPU = new ObservableCollection<Specification>()
            {
                new("Manufacturer", pc.GPU.GPU_Manufacturer),
                new("Memory Support", pc.GPU.GPU_MemorySupport),
                new("Recommended Power Supply", pc.GPU.GPU_RecommendedPowerSupply.ToString()),
            };

            _Motherboard = new ObservableCollection<Specification>()
            {
                new("CPU Spport", pc.Motherboard.Motherboard_CPU_Spport),
                new("Socket", pc.Motherboard.Motherboard_Socket),
                new("Formfactor", pc.Motherboard.Motherboard_FormFactor),
                new("Memory Support", pc.Motherboard.Motherboard_MemorySupport),
                new("Number Of RAM Slots", pc.Motherboard.Motherboard_NumberOf_RAM_Slots.ToString()),
                new("Maximum RAM Capacity", pc.Motherboard.Motherboard_Maximum_RAM_Capacity.ToString()),
                new("Maximum RAM Frequency", pc.Motherboard.Motherboard_Maximum_RAM_Frequency.ToString()),
                new("Number Of M2 Slots", pc.Motherboard.Motherboard_NumberOf_M2_Slots.ToString()),
                new("Number Of SATA3 Slots", pc.Motherboard.Motherboard_NumberOf_SATA3_Slots.ToString()),
            };

            _RAM = new ObservableCollection<Specification>()
            {
                new("Overall Volume", pc.RAM.RAM_OverallVolume.ToString()),
                new("Memory Type", pc.RAM.RAM_MemoryType),
                new("Frequency", pc.RAM.RAM_Frequency.ToString()),
            };

            _SSD = new ObservableCollection<Specification>()
            {
                new("FormFactor", pc.SSD.SSD_FormFactor),
                new("Size", pc.SSD.SSD_Size),
            };

            string supportCooling = "";
            foreach (var item in pc.CoolingSystem.CoolingSysrem_Socket)
                supportCooling += (item + ", ");

            _CoolingSystem = new ObservableCollection<Specification>()
            {
                new("Supported Socket", supportCooling),
                new("TDP", pc.CoolingSystem.CoolingSysrem_TDP.ToString()),
            };

            _PowerUnit = new ObservableCollection<Specification>()
            {
                new("Power", pc.PowerUnit.PowerUnit_Power.ToString() + "W"),
                new("Formfactor", pc.PowerUnit.PowerUnit_FormFactor),
            };

            string support = "";
            foreach (var item in pc.ComputerCase.ComputerCase_SupportedMotherboards)
                support += (item + ", ");


            _ComputerCase = new ObservableCollection<Specification>()
            {
                new("Supported Motherboards", support),
            };
        }
    }
}
