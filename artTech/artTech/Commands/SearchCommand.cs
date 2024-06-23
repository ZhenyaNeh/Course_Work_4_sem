using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using artTech.Data;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using artTech.Controll;
using Microsoft.EntityFrameworkCore;

namespace artTech.Commands
{
    internal class SearchCommand : BaseCommand
    {

        public override void Execute(string? search, string? filter, ItemsControl? catalog, RoutedEventHandler? itemButtonClickHandler)
        {
            using (var context = new ConfigPCContext())
            {
                switch (filter)
                {
                    case nameof(EnumConfig.Components.CPU):
                        var list_CPU = context.CPUs.ToList();
                        foreach(var item in list_CPU)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.GPU):
                        var list_GPU = context.GPUs.ToList();
                        foreach (var item in list_GPU)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.MotherBoard):
                        var list_MotherBoard = context.Motherboards.ToList();
                        foreach (var item in list_MotherBoard)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.RAM):
                        var list_RAM = context.RAMs.ToList();
                        foreach (var item in list_RAM)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.SSD):
                        var list_SSD = context.SSDs.ToList();
                        foreach (var item in list_SSD)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.CoolingSystem):
                        var list_CoolingSystem = context.CoolingSystems.ToList();
                        foreach (var item in list_CoolingSystem)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.PowerUnit):
                        var list_PowerUnit = context.PowerUnits.ToList();
                        foreach (var item in list_PowerUnit)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.ComputerCase):
                        var list_ComputerCase = context.ComputerCases.ToList();
                        foreach (var item in list_ComputerCase)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    case nameof(EnumConfig.Components.PC):

                        Account_Control.UpdateInformation();
                        List<Models.PC> list_PC = new List<Models.PC>();

                        foreach (var publish in Account_Control.Admins)
                        {
                            var list = context.PCs
                               .Include(p => p.CPU)
                               .Include(p => p.GPU)
                               .Include(p => p.Motherboard)
                               .Include(p => p.RAM)
                               .Include(p => p.SSD)
                               .Include(p => p.CoolingSystem)
                               .Include(p => p.PowerUnit)
                               .Include(p => p.ComputerCase)
                               .Where(p => p.AdminId == publish.Id)
                               .ToList();

                            foreach (var item in list)
                                list_PC.Add(item);
                        }

                        foreach (var item in list_PC)
                            ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);

                        break;
                    default:
                        var list_Def_PC = context.CPUs.ToList();
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
