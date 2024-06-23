using artTech.Data;
using artTech.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
using artTech.Controll;

namespace artTech.Commands
{
    class ViewItemConfigCommand : BaseCommand
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
                        ViewItemConfigPage cpuPage = new ViewItemConfigPage(_CPU);
                        navigation?.Navigate(cpuPage);

                        break;
                    case nameof(EnumConfig.Components.GPU):
                        var _GPU = context.GPUs.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage gpuPage = new ViewItemConfigPage(_GPU);
                        navigation?.Navigate(gpuPage);

                        break;
                    case nameof(EnumConfig.Components.MotherBoard):
                        var _MotherBoard = context.Motherboards.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage motherboardPage = new ViewItemConfigPage(_MotherBoard);
                        navigation?.Navigate(motherboardPage);

                        break;
                    case nameof(EnumConfig.Components.RAM):
                        var _RAM = context.RAMs.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage ramPage = new ViewItemConfigPage(_RAM);
                        navigation?.Navigate(ramPage);

                        break;
                    case nameof(EnumConfig.Components.SSD):
                        var _SSD = context.SSDs.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage ssdPage = new ViewItemConfigPage(_SSD);
                        navigation?.Navigate(ssdPage);

                        break;
                    case nameof(EnumConfig.Components.CoolingSystem):
                        var _CoolingSystem = context.CoolingSystems.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage coolingSystemPage = new ViewItemConfigPage(_CoolingSystem);
                        navigation?.Navigate(coolingSystemPage);

                        break;
                    case nameof(EnumConfig.Components.PowerUnit):
                        var _PowerUnit = context.PowerUnits.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage powerUnitPage = new ViewItemConfigPage(_PowerUnit);
                        navigation?.Navigate(powerUnitPage);

                        break;
                    case nameof(EnumConfig.Components.ComputerCase):
                        var _ComputerCase = context.ComputerCases.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage computerCasePage = new ViewItemConfigPage(_ComputerCase);
                        navigation?.Navigate(computerCasePage);

                        break;
                    default:
                        var defaultVarian = context.CPUs.Where(x => x.Id == buttonID).First();
                        ViewItemConfigPage defaultPage = new ViewItemConfigPage(defaultVarian);
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
