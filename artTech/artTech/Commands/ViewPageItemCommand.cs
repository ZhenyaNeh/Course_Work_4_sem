using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;
using artTech.Data;
using artTech.Pages;
using MaterialDesignColors;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace artTech.Commands
{
    internal class ViewPageItemCommand : BaseCommand
    {
        public override void Execute(object? sender, string? table, NavigationService? navigation)
        {
            string buttonName = ((Button)sender).Name;

            int buttonID = Int32.Parse(buttonName.Replace("ProductItem_", ""));


            using (var context = new ConfigPCContext())
            {
                switch (table)
                {
                    case nameof(EnumConfig.Components.CPU):
                        var _CPU = context.CPUs.Where(x => x.Id == buttonID).First();
                        ViewItemPage cpuPage = new ViewItemPage(_CPU);
                        navigation?.Navigate(cpuPage);

                        break;
                    case nameof(EnumConfig.Components.GPU):
                        var _GPU = context.GPUs.Where(x => x.Id == buttonID).First();
                        ViewItemPage gpuPage = new ViewItemPage(_GPU);
                        navigation?.Navigate(gpuPage);

                        break;
                    case nameof(EnumConfig.Components.MotherBoard):
                        var _MotherBoard = context.Motherboards.Where(x => x.Id == buttonID).First();
                        ViewItemPage motherboardPage = new ViewItemPage(_MotherBoard);
                        navigation?.Navigate(motherboardPage);

                        break;
                    case nameof(EnumConfig.Components.RAM):
                        var _RAM = context.RAMs.Where(x => x.Id == buttonID).First();
                        ViewItemPage ramPage = new ViewItemPage(_RAM);
                        navigation?.Navigate(ramPage);

                        break;
                    case nameof(EnumConfig.Components.SSD):
                        var _SSD = context.SSDs.Where(x => x.Id == buttonID).First();
                        ViewItemPage ssdPage = new ViewItemPage(_SSD);
                        navigation?.Navigate(ssdPage);

                        break;
                    case nameof(EnumConfig.Components.CoolingSystem):
                        var _CoolingSystem = context.CoolingSystems.Where(x => x.Id == buttonID).First();
                        ViewItemPage coolingSystemPage = new ViewItemPage(_CoolingSystem);
                        navigation?.Navigate(coolingSystemPage);

                        break;
                    case nameof(EnumConfig.Components.PowerUnit):
                        var _PowerUnit = context.PowerUnits.Where(x => x.Id == buttonID).First();
                        ViewItemPage powerUnitPage = new ViewItemPage(_PowerUnit);
                        navigation?.Navigate(powerUnitPage);

                        break;
                    case nameof(EnumConfig.Components.ComputerCase):
                        var _ComputerCase = context.ComputerCases.Where(x => x.Id == buttonID).First();
                        ViewItemPage computerCasePage = new ViewItemPage(_ComputerCase);
                        navigation?.Navigate(computerCasePage);

                        break;
                    case nameof(EnumConfig.Components.PC):

                        //var _PC = context.PCs.Where(x => x.Id == buttonID).First();
                        var _PC = context.PCs
                               .Include(p => p.CPU)
                               .Include(p => p.GPU)
                               .Include(p => p.Motherboard)
                               .Include(p => p.RAM)
                               .Include(p => p.SSD)
                               .Include(p => p.CoolingSystem)
                               .Include(p => p.PowerUnit)
                               .Include(p => p.ComputerCase)
                               .Where(p => p.Id == buttonID).First();


                        ViewItemPage_PC pcPage = new ViewItemPage_PC(_PC);
                        navigation?.Navigate(pcPage);

                        break;
                    default:
                        var defaultVarian = context.CPUs.Where(x => x.Id == buttonID).First();
                        ViewItemPage defaultPage = new ViewItemPage(defaultVarian);
                        navigation?.Navigate(defaultPage);
                        break;
                }
            }
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(string? searcch, string? filter, ItemsControl? prod, RoutedEventHandler? itemButtonClickHandler)
        {
            throw new NotImplementedException();
        }
    }
}
