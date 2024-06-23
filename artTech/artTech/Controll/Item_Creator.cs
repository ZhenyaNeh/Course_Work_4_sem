using artTech.Data;
using artTech.Models;
using artTech.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Controll
{
    public static class Item_Creator
    {
        private static MyRepository<CPU> cpuRepositoty = new MyRepository<CPU>(new ConfigPCContext());
        private static MyRepository<GPU> gpuRepositoty = new MyRepository<GPU>(new ConfigPCContext());
        private static MyRepository<Motherboard> motherboardRepositoty = new MyRepository<Motherboard>(new ConfigPCContext());
        private static MyRepository<RAM> ramRepositoty = new MyRepository<RAM>(new ConfigPCContext());
        private static MyRepository<SSD> ssdRepositoty = new MyRepository<SSD>(new ConfigPCContext());
        private static MyRepository<CoolingSystem> coolingSystemRepositoty = new MyRepository<CoolingSystem>(new ConfigPCContext());
        private static MyRepository<PowerUnit> powerUnitRepositoty = new MyRepository<PowerUnit>(new ConfigPCContext());
        private static MyRepository<ComputerCase> computerCaseRepositoty = new MyRepository<ComputerCase>(new ConfigPCContext());


        public static CPU? CPU { get; set; }
        public static GPU? GPU { get; set; }
        public static Motherboard? Motherboard { get; set; }
        public static RAM? RAM { get; set; }
        public static SSD? SSD { get; set; }
        public static CoolingSystem? CoolingSystem { get; set; }
        public static PowerUnit? PowerUnit { get; set; }
        public static ComputerCase? ComputerCase { get; set; }

        static Item_Creator()
        {
            CPU = new CPU();
            GPU = new GPU();
            Motherboard = new Motherboard();
            RAM = new RAM();
            SSD = new SSD();
            CoolingSystem = new CoolingSystem();
            PowerUnit = new PowerUnit();
            ComputerCase = new ComputerCase();
        }

        public static void Crear()
        {
            CPU = new CPU();
            GPU = new GPU();
            Motherboard = new Motherboard();
            RAM = new RAM();
            SSD = new SSD();
            CoolingSystem = new CoolingSystem();
            PowerUnit = new PowerUnit();
            ComputerCase = new ComputerCase();
        }

        public static bool CheckingCPU()
        {
            try
            {
                if (CPU != null && 
                    CPU.CPU_Manufacturer != null && 
                    CPU.CPU_Socket != null && 
                    CPU.CPU_MemorySupport != null &&
                    CPU.CPU_IntegratedGraphics != null)
                {
                    if (CPU.CPU_Manufacturer != "" &&
                        CPU.CPU_Socket != "" &&
                        CPU.CPU_MemorySupport != "" &&
                        CPU.CPU_IntegratedGraphics != "" &&
                        CPU.CPU_TDP != 0)
                    {
                        using (var context = new ConfigPCContext())
                        {
                            cpuRepositoty.Create(CPU);
                        }
                        CPU = new CPU();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingGPU()
        {
            try
            {
                if (GPU != null &&
                    GPU.GPU_Manufacturer != null &&
                    GPU.GPU_MemorySupport != null)
                {
                    if (GPU.GPU_Manufacturer != "" &&
                        GPU.GPU_MemorySupport != "" &&
                        GPU.GPU_RecommendedPowerSupply != 0)
                    {
                        using (var context = new ConfigPCContext())
                        {
                            gpuRepositoty.Create(GPU);
                        }
                        GPU = new GPU();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingMotherboard()
        {
            try
            {
                if (Motherboard != null &&
                    Motherboard.Motherboard_CPU_Spport != null &&
                    Motherboard.Motherboard_Socket != null &&
                    Motherboard.Motherboard_FormFactor != null &&
                    Motherboard.Motherboard_MemorySupport != null)
                {
                    if (Motherboard.Motherboard_CPU_Spport != "" &&
                        Motherboard.Motherboard_Socket != "" &&
                        Motherboard.Motherboard_FormFactor != "" &&
                        Motherboard.Motherboard_MemorySupport != "" &&
                        Motherboard.Motherboard_NumberOf_RAM_Slots != 0 &&
                        Motherboard.Motherboard_Maximum_RAM_Capacity != 0 &&
                        Motherboard.Motherboard_Maximum_RAM_Frequency != 0 &&
                        Motherboard.Motherboard_NumberOf_M2_Slots != 0 &&
                        Motherboard.Motherboard_NumberOf_SATA3_Slots != 0 )
                    {
                        using (var context = new ConfigPCContext())
                        {
                            motherboardRepositoty.Create(Motherboard);
                        }
                        Motherboard = new Motherboard();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingRAM()
        {
            try
            {
                if (RAM != null &&
                    RAM.RAM_MemoryType != null)
                {
                    if (RAM.RAM_MemoryType != "" &&
                        RAM.RAM_CountOfSticks != 0 &&
                        RAM.RAM_OverallVolume != 0 &&
                        RAM.RAM_Frequency != 0 )
                    {
                        using (var context = new ConfigPCContext())
                        {
                            ramRepositoty.Create(RAM);
                        }
                        RAM = new RAM();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingSSD()
        {
            try
            {
                if (SSD != null &&
                    SSD.SSD_FormFactor != null &&
                    SSD.SSD_Size != null)
                {
                    if (SSD.SSD_FormFactor != "" &&
                        SSD.SSD_Size != "" )
                    {
                        using (var context = new ConfigPCContext())
                        {
                            ssdRepositoty.Create(SSD);
                        }
                        SSD = new SSD();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingCoolingSystem()
        {
            try
            {
                if (CoolingSystem != null &&
                    CoolingSystem.CoolingSysrem_Socket != null)
                {
                    if (CoolingSystem.CoolingSysrem_Socket.Count >= 2 &&
                        CoolingSystem.CoolingSysrem_TDP != 0)
                    {
                        using (var context = new ConfigPCContext())
                        {
                            coolingSystemRepositoty.Create(CoolingSystem);
                        }
                        CoolingSystem = new CoolingSystem();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingPowerUnit()
        {
            try
            {
                if (PowerUnit != null &&
                    PowerUnit.PowerUnit_FormFactor != null)
                {
                    if (PowerUnit.PowerUnit_FormFactor != "" &&
                        PowerUnit.PowerUnit_Power != 0)
                    {
                        using (var context = new ConfigPCContext())
                        {
                            powerUnitRepositoty.Create(PowerUnit);
                        }
                        PowerUnit = new PowerUnit();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static bool CheckingComputerCase()
        {
            try
            {
                if (ComputerCase != null && ComputerCase.ComputerCase_SupportedMotherboards != null)
                {
                    if (ComputerCase.ComputerCase_SupportedMotherboards.Count >= 2)
                    {
                        using (var context = new ConfigPCContext())
                        {
                            computerCaseRepositoty.Create(ComputerCase);
                        }
                        ComputerCase = new ComputerCase();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

    }
}
