using artTech.Commands;
using artTech.Models;
using artTech.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Controll
{
    public static class PC_ConfigBuilder
    {
        public static PC pc { set; get; } 

        static PC_ConfigBuilder() 
        {
            pc = new PC();
        }

        public static void AddNewComponent(object component)
        {
            switch (component)
            {
                case CPU cpu:
                    pc.CPU = cpu;
                    if (!true)
                    {
                        pc.CPU = null;
                    }

                    break;
                case GPU gpu:
                    pc.GPU = gpu;
                    if (!true)
                    {
                        pc.GPU = null;
                    }

                    break;
                case CoolingSystem coolingSystem:
                    pc.CoolingSystem = coolingSystem;
                    if (!true)
                    {
                        pc.CoolingSystem = null;
                    }

                    break;
                case ComputerCase computerCase:
                    pc.ComputerCase = computerCase;
                    if (!true)
                    {
                        pc.ComputerCase = null;
                    }

                    break;
                case Motherboard motherboard:
                    pc.Motherboard = motherboard;
                    if (!true)
                    {
                        pc.Motherboard = null;
                    }

                    break;
                case PowerUnit powerUnit:
                    pc.PowerUnit = powerUnit;
                    if (!true)
                    {
                        pc.PowerUnit = null;
                    }

                    break;
                case RAM ram:
                    pc.RAM = ram;
                    if (!true)
                    {
                        pc.RAM = null;
                    }

                    break;
                case SSD ssd:
                    pc.SSD = ssd;
                    if (!true)
                    {
                        pc.SSD = new SSD();
                    }

                    break;
                default:

                    break;
            }
        }

        public static List<CPU> CheckingCPUCompatibility(List<CPU> list_CPU)
        {
            if (pc.CoolingSystem != null && pc.CoolingSystem.Id != 0)
            {
                list_CPU = list_CPU.Where(x => pc.CoolingSystem.CoolingSysrem_Socket.Contains(x.CPU_Socket))
                                   .Where(x => x.CPU_TDP <= pc.CoolingSystem.CoolingSysrem_TDP).ToList();
            }
            else if (pc.Motherboard != null && pc.Motherboard.Id != 0)
            {
                list_CPU = list_CPU.Where(x => x.CPU_Socket == pc.Motherboard.Motherboard_Socket).ToList();
            }

            return list_CPU;
        }
        public static List<GPU> CheckingGPUCompatibility(List<GPU> list_GPU)
        {
            if (pc.PowerUnit != null && pc.PowerUnit.Id != 0)
            {
                list_GPU = list_GPU.Where(x => x.GPU_RecommendedPowerSupply <= pc.PowerUnit.PowerUnit_Power).ToList();
            }

            return list_GPU;
        }

        public static List<Motherboard> CheckingMotherBoardCompatibility(List<Motherboard> list_Motherboard)
        {
            if (pc.CPU != null && pc.CPU.Id != 0)
            {
                list_Motherboard = list_Motherboard.Where(x => x.Motherboard_Socket == pc.CPU.CPU_Socket).ToList();
            }
            else if (pc.CoolingSystem != null && pc.CoolingSystem.Id != 0)
            {
                list_Motherboard = list_Motherboard.Where(x => pc.CoolingSystem.CoolingSysrem_Socket.Contains(x.Motherboard_Socket)).ToList();
            }

            if(pc.RAM != null && pc.RAM.Id != 0)
            {
                list_Motherboard = list_Motherboard.Where(x => x.Motherboard_MemorySupport == pc.RAM.RAM_MemoryType)
                                                   .Where(x => x.Motherboard_Maximum_RAM_Frequency >= pc.RAM.RAM_Frequency)
                                                   .Where(x => x.Motherboard_NumberOf_RAM_Slots >= pc.RAM.RAM_CountOfSticks)
                                                   .Where(x => x.Motherboard_Maximum_RAM_Capacity >= pc.RAM.RAM_OverallVolume).ToList();
            }

            if(pc.SSD != null && pc.SSD.Id != 0)
            {
                if(pc.SSD.SSD_FormFactor == "M.2")
                    list_Motherboard = list_Motherboard.Where(x => x.Motherboard_NumberOf_M2_Slots > 0).ToList();
                else 
                    list_Motherboard = list_Motherboard.Where(x => x.Motherboard_NumberOf_SATA3_Slots > 0).ToList();
            }

            if(pc.ComputerCase != null && pc.ComputerCase.Id != 0)
            {
                list_Motherboard = list_Motherboard.Where(x => pc.ComputerCase.ComputerCase_SupportedMotherboards.Contains(x.Motherboard_Socket)).ToList();
            }

            return list_Motherboard;
        }

        public static List<CoolingSystem> CheckingCoolingSystemCompatibility(List<CoolingSystem> list_CoolingSystem)
        {
            if(pc.CPU != null && pc.CPU.Id != 0)
            {
                list_CoolingSystem = list_CoolingSystem.Where(x => x.CoolingSysrem_Socket.Contains(pc.CPU.CPU_Socket))
                                                       .Where(x => x.CoolingSysrem_TDP >= pc.CPU.CPU_TDP).ToList();
            }
            else if (pc.Motherboard != null && pc.Motherboard.Id != 0)
            {
                list_CoolingSystem = list_CoolingSystem.Where(x => x.CoolingSysrem_Socket.Contains(pc.Motherboard.Motherboard_Socket)).ToList();
            }

            return list_CoolingSystem;
        }

        public static List<RAM> CheckingRAMCompatibility(List<RAM> list_RAM)
        {
            if (pc.Motherboard != null && pc.Motherboard.Id != 0)
            {
                list_RAM = list_RAM.Where(x => x.RAM_MemoryType == pc.Motherboard.Motherboard_MemorySupport)
                                   .Where(x => x.RAM_Frequency <= pc.Motherboard.Motherboard_Maximum_RAM_Frequency)
                                   .Where(x => x.RAM_CountOfSticks <= pc.Motherboard.Motherboard_NumberOf_RAM_Slots)
                                   .Where(x => x.RAM_OverallVolume <= pc.Motherboard.Motherboard_Maximum_RAM_Capacity).ToList();
            }

            return list_RAM;
        }

        public static List<SSD> CheckingSSDCompatibility(List<SSD> list_SSD)
        {
            if (pc.Motherboard != null && pc.Motherboard.Id != 0)
            {
                if((pc.Motherboard.Motherboard_NumberOf_M2_Slots > 0) && !(pc.Motherboard.Motherboard_NumberOf_SATA3_Slots > 0))
                {
                    list_SSD = list_SSD.Where(x => x.SSD_FormFactor == "M.2").ToList();
                }
                else if (!(pc.Motherboard.Motherboard_NumberOf_M2_Slots > 0) && (pc.Motherboard.Motherboard_NumberOf_SATA3_Slots > 0))
                {
                    list_SSD = list_SSD.Where(x => x.SSD_FormFactor == "SATA3").ToList();
                }
            }

            return list_SSD;
        }

        public static List<PowerUnit> CheckingPowerUnitCompatibility(List<PowerUnit> list_PowerUnit)
        {
            if(pc.GPU != null && pc.GPU.Id != 0)
            {
                list_PowerUnit = list_PowerUnit.Where(x => x.PowerUnit_Power >= pc.GPU.GPU_RecommendedPowerSupply).ToList();
            }

            return list_PowerUnit;
        }

        public static List<ComputerCase> CheckingComputerCaseCompatibility(List<ComputerCase> list_ComputerCase)
        {
            if(pc.Motherboard != null && pc.Motherboard.Id != 0)
            {
                list_ComputerCase = list_ComputerCase.Where(x => x.ComputerCase_SupportedMotherboards.Contains(pc.Motherboard.Motherboard_FormFactor)).ToList();
            }

            return list_ComputerCase;
        }

        /*public static bool CheckingSocketCompatibility()
        {

            return true;
        }
        public static bool CheckingCoolingCompatibility()
        {

            return true;
        }

        public static bool CheckingGPUCompatibility()
        {

            return true;
        }

        public static bool CheckingMotherboardCompatibility()
        {

            return true;
        }

        public static bool CheckingRAMCompatibility()
        {

            return true;
        }

        public static bool CheckingMemoryCompatibility()
        {

            return true;
        }

        public static bool CheckingPowerCompatibility()
        {

            return true;
        }*/
    }
}
