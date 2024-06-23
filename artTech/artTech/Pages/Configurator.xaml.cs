using artTech.Commands;
using artTech.Controll;
using artTech.Data;
using artTech.Models;
using artTech.Models.Peeson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace artTech.Pages
{
    /// <summary>
    /// Interaction logic for Configurator.xaml
    /// </summary>
    public partial class Configurator : Page
    {
        public Catalog catalogPage;
        private static MyRepository<PC> pcRepositoty = new MyRepository<PC>(new ConfigPCContext());
        private static MyRepository<User> userRepositoty = new MyRepository<User>(new ConfigPCContext());
        private static MyRepository<Admin> adminRepositoty = new MyRepository<Admin>(new ConfigPCContext());

        public static event EventHandler LoadHomePage;
        public Configurator()
        {
            InitializeComponent();
            catalogPage = new Catalog(false);
            ViewItemConfigPage.UpdateItesmConfig += UpdateImage;
            ViewItemConfigPage.ChangeItesmConfig += ChangeItem;
        }


        private bool SelectedItem { set; get; } = false;
        private decimal PriceConfig { set; get; }

        private void ResetBorderBrush()
        {
            Border_ComputerCase.BorderBrush = Brushes.Transparent;
            Border_CoolingSystem.BorderBrush = Brushes.Transparent;
            Border_CPU.BorderBrush = Brushes.Transparent;
            Border_GPU.BorderBrush = Brushes.Transparent;
            Border_MotherBoard.BorderBrush = Brushes.Transparent;
            Border_PowerUnit.BorderBrush = Brushes.Transparent;
            Border_RAM.BorderBrush = Brushes.Transparent;
            Border_SSD.BorderBrush = Brushes.Transparent;
        } 
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!SelectedItem)
            {
                ResetBorderBrush();
                //HintTitle.Visibility = Visibility.Visible;
                //ConfigFrame.Content = null;
            }
            SelectedItem = false;
        }

        private void ShowCatalog(object sender, MouseButtonEventArgs e)
        {
            catalogPage.CreatorConfigItems(((Border)sender).Name.Replace("Border_", ""));
            ConfigFrame.Content = catalogPage;
        }

        private void BorderThickness_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetBorderBrush();
            ((Border)sender).BorderBrush = Brushes.Gray;
            HintTitle.Visibility = Visibility.Collapsed;
            SelectedItem = true;

            switch (((Border)sender).Name.Replace("Border_", ""))
            {
                case nameof(EnumConfig.Components.CPU):
                    if(PC_ConfigBuilder.pc.CPU != null && PC_ConfigBuilder.pc.CPU.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.CPU);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.GPU):
                    if (PC_ConfigBuilder.pc.GPU != null && PC_ConfigBuilder.pc.GPU.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.GPU);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.MotherBoard):
                    if (PC_ConfigBuilder.pc.Motherboard != null && PC_ConfigBuilder.pc.Motherboard.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.Motherboard);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.RAM):
                    if (PC_ConfigBuilder.pc.RAM != null && PC_ConfigBuilder.pc.RAM.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.RAM);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.SSD):
                    if (PC_ConfigBuilder.pc.SSD != null && PC_ConfigBuilder.pc.SSD.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.SSD);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.CoolingSystem):
                    if (PC_ConfigBuilder.pc.CoolingSystem != null && PC_ConfigBuilder.pc.CoolingSystem.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.CoolingSystem);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.PowerUnit):
                    if (PC_ConfigBuilder.pc.PowerUnit != null && PC_ConfigBuilder.pc.PowerUnit.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.PowerUnit);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                case nameof(EnumConfig.Components.ComputerCase):
                    if (PC_ConfigBuilder.pc.ComputerCase != null && PC_ConfigBuilder.pc.ComputerCase.Id != 0)
                    {
                        ConfigFrame.Content = new ViewItemConfigPage(PC_ConfigBuilder.pc.ComputerCase);
                        break;
                    }

                    ShowCatalog(sender, e);
                    break;
                default:
                    
                    ShowCatalog(sender, e);
                    break;
            }
        }

        public void UpdateImage(Object sender, EventArgs e)
        {
            double progress = 0;
            decimal price = 0;

            if(PC_ConfigBuilder.pc.CPU != null && PC_ConfigBuilder.pc.CPU.Id != 0)
            {
                CPU_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.CPU.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.CPU.Price;
            }

            if (PC_ConfigBuilder.pc.GPU != null && PC_ConfigBuilder.pc.GPU.Id != 0)
            {
                GPU_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.GPU.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.GPU.Price;
            }

            if (PC_ConfigBuilder.pc.Motherboard != null && PC_ConfigBuilder.pc.Motherboard.Id != 0)
            {
                Motherboard_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.Motherboard.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.Motherboard.Price;
            }

            if (PC_ConfigBuilder.pc.RAM != null && PC_ConfigBuilder.pc.RAM.Id != 0)
            {
                RAM_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.RAM.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.RAM.Price;
            }

            if (PC_ConfigBuilder.pc.SSD != null && PC_ConfigBuilder.pc.SSD.Id != 0)
            {
                SSD_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.SSD.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.SSD.Price;
            }

            if (PC_ConfigBuilder.pc.CoolingSystem != null && PC_ConfigBuilder.pc.CoolingSystem.Id != 0)
            {
                CoolingSystem_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.CoolingSystem.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.CoolingSystem.Price;
            }

            if (PC_ConfigBuilder.pc.PowerUnit != null && PC_ConfigBuilder.pc.PowerUnit.Id != 0)
            {
                PowerUnit_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.PowerUnit.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.PowerUnit.Price;
            }

            if (PC_ConfigBuilder.pc.ComputerCase != null && PC_ConfigBuilder.pc.ComputerCase.Id != 0)
            {
                ComputerCase_Image.Source = new BitmapImage(new Uri(PC_ConfigBuilder.pc.ComputerCase.Image));
                progress += 12.5;
                price += PC_ConfigBuilder.pc.ComputerCase.Price;
            }

            ProgerssBas.Value = progress;
            ProcentValue.Text = progress.ToString() + "%";

            Underline underline = new Underline();
            underline.Inlines.Add("Total Price: " + price.ToString() + "$");
            TotalPrice.Inlines.Clear();
            TotalPrice.Inlines.Add(underline);

            PriceConfig = price;

            //TotalPrice.Text = "Total Price: " + price.ToString() + "$";
        }

        public void ChangeItem(Object sender, EventArgs e)
        {
            catalogPage.CreatorConfigItems(sender.ToString());
            ConfigFrame.Content = catalogPage;
            //ShowCatalog(sender, e as MouseButtonEventArgs);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if(ProgerssBas.Value != 100)
            {
                Button button = sender as Button;

                if (button != null && button.ToolTip != null)
                {
                    ToolTip toolTip = button.ToolTip as ToolTip;
                    if (toolTip == null)
                    {
                        toolTip = new ToolTip { Content = button.ToolTip.ToString() };
                        button.ToolTip = toolTip;
                    }

                    toolTip.PlacementTarget = button;
                    toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                    toolTip.IsOpen = true;

                    DispatcherTimer timer = new DispatcherTimer
                    {
                        Interval = TimeSpan.FromSeconds(2)
                    };
                    timer.Tick += (s, args) =>
                    {
                        toolTip.IsOpen = false;
                        timer.Stop();
                    };
                    timer.Start();
                }
            }
            else
            {
                PC_ConfigBuilder.pc.Name = PC_ConfigBuilder.pc.ComputerCase.Name;
                PC_ConfigBuilder.pc.Image = PC_ConfigBuilder.pc.ComputerCase.Image;
                PC_ConfigBuilder.pc.Price = PriceConfig;

                if (Account_Control.CurrentUserSignIn)
                {
                    using (var context = new ConfigPCContext())
                    {
                        if (Account_Control.CurrentUserIsAdmin)
                        {
                            Account_Control.CurrentAdmin.PublishPC.Add(PC_ConfigBuilder.pc);
                            adminRepositoty.Update(Account_Control.CurrentAdmin);
                        }
                        else
                        {
                            Account_Control.CurrentUser.SaveConfig.Add(PC_ConfigBuilder.pc);
                            userRepositoty.Update(Account_Control.CurrentUser);
                        }
                    }

                    Account_Control.UpdateInformation();
                    LoadHomePage.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
