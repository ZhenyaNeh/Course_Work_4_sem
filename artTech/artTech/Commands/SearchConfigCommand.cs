using artTech.Controll;
using artTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows;

namespace artTech.Commands
{
    public class SearchConfigCommand : BaseCommand
    {
        public override void Execute(string? search, string? filter, ItemsControl? catalog, RoutedEventHandler? itemButtonClickHandler)
        {
            using (var context = new ConfigPCContext())
            {
                switch (filter)
                {
                    case nameof(EnumConfig.Components.CPU):
                        var list_CPU = context.CPUs.ToList();

                        list_CPU = PC_ConfigBuilder.CheckingCPUCompatibility(list_CPU);

                        foreach (var item in list_CPU)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.GPU):
                        var list_GPU = context.GPUs.ToList();

                        list_GPU = PC_ConfigBuilder.CheckingGPUCompatibility(list_GPU);

                        foreach (var item in list_GPU)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.MotherBoard):
                        var list_MotherBoard = context.Motherboards.ToList();

                        list_MotherBoard = PC_ConfigBuilder.CheckingMotherBoardCompatibility(list_MotherBoard);

                        foreach (var item in list_MotherBoard)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.RAM):
                        var list_RAM = context.RAMs.ToList();

                        list_RAM = PC_ConfigBuilder.CheckingRAMCompatibility(list_RAM);

                        foreach (var item in list_RAM)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.SSD):
                        var list_SSD = context.SSDs.ToList();

                        list_SSD = PC_ConfigBuilder.CheckingSSDCompatibility(list_SSD);

                        foreach (var item in list_SSD)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.CoolingSystem):
                        var list_CoolingSystem = context.CoolingSystems.ToList();

                        list_CoolingSystem = PC_ConfigBuilder.CheckingCoolingSystemCompatibility(list_CoolingSystem);

                        foreach (var item in list_CoolingSystem)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.PowerUnit):
                        var list_PowerUnit = context.PowerUnits.ToList();

                        list_PowerUnit = PC_ConfigBuilder.CheckingPowerUnitCompatibility(list_PowerUnit);

                        foreach (var item in list_PowerUnit)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.ComputerCase):
                        var list_ComputerCase = context.ComputerCases.ToList();

                        list_ComputerCase = PC_ConfigBuilder.CheckingComputerCaseCompatibility(list_ComputerCase);

                        foreach (var item in list_ComputerCase)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    default:
                        var list_Def_PC = context.CPUs.ToList();

                        list_Def_PC = PC_ConfigBuilder.CheckingCPUCompatibility(list_Def_PC);

                        foreach (var item in list_Def_PC)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);
                        break;
                }
            }
        }

        public override void Execute(object? parameter, string? table, NavigationService? navigation)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

    }
}
