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
using Microsoft.EntityFrameworkCore;

namespace artTech.Commands
{
    public class ViewUserPCCommand : BaseCommand
    {
        public override void Execute(string? search, string? filter, ItemsControl? catalog, RoutedEventHandler? itemButtonClickHandler)
        {
            using (var context = new ConfigPCContext())
            {
                var list_User_PC = context.PCs
                .Include(p => p.CPU)
                .Include(p => p.GPU)
                .Include(p => p.Motherboard)
                .Include(p => p.RAM)
                .Include(p => p.SSD)
                .Include(p => p.CoolingSystem)
                .Include(p => p.PowerUnit)
                .Include(p => p.ComputerCase)
                .Where(p => p.UserId == Account_Control.CurrentUser.Id)
                .ToList();

                foreach (var item in list_User_PC)
                    ViewCatalogItem.ViewCatalogItems(search, item.Id, item.Name, item.Image, item.Price, catalog, itemButtonClickHandler);
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
