using artTech.Commands;
using artTech.Controll;
using artTech.Models;
using artTech.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace artTech.Pages
{
    /// <summary>
    /// Interaction logic for ViewItemConfigPage.xaml
    /// </summary>
    public partial class ViewItemConfigPage : Page
    {
        public object SendObject {  get; set; }

        public static event EventHandler UpdateItesmConfig;
        public static event EventHandler ChangeItesmConfig;

        public ViewItemConfigPage(CPU cpu)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(cpu.Name);
            Title.Inlines.Add(underline);
            Price.Text = cpu.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(cpu.Image));

            if(PC_ConfigBuilder.pc.CPU != null)
            {
                if (cpu.Id == PC_ConfigBuilder.pc.CPU.Id)
                { 
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new CPU_ViewModel(cpu);

            SendObject = cpu;
        }

        public ViewItemConfigPage(GPU gpu)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(gpu.Name);
            Title.Inlines.Add(underline);
            Price.Text = gpu.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(gpu.Image));

            if (PC_ConfigBuilder.pc.GPU != null)
            {
                if (gpu.Id == PC_ConfigBuilder.pc.GPU.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new GPU_ViewModel(gpu);

            SendObject = gpu;
        }

        public ViewItemConfigPage(ComputerCase computerCase)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(computerCase.Name);
            Title.Inlines.Add(underline);
            Price.Text = computerCase.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(computerCase.Image));

            if (PC_ConfigBuilder.pc.ComputerCase != null)
            {
                if (computerCase.Id == PC_ConfigBuilder.pc.ComputerCase.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new ComputerCase_ViewModel(computerCase);

            SendObject = computerCase;
        }

        public ViewItemConfigPage(CoolingSystem coolingSystem)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(coolingSystem.Name);
            Title.Inlines.Add(underline);
            Price.Text = coolingSystem.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(coolingSystem.Image));

            if (PC_ConfigBuilder.pc.CoolingSystem != null)
            {
                if (coolingSystem.Id == PC_ConfigBuilder.pc.CoolingSystem.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new CoolingSystem_ViewModel(coolingSystem);

            SendObject = coolingSystem;
        }

        public ViewItemConfigPage(Motherboard motherboard)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(motherboard.Name);
            Title.Inlines.Add(underline);
            Price.Text = motherboard.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(motherboard.Image));

            if (PC_ConfigBuilder.pc.Motherboard != null)
            {
                if (motherboard.Id == PC_ConfigBuilder.pc.Motherboard.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new Motherboard_ViewModel(motherboard);

            SendObject = motherboard;
        }

        /*public ViewItemPage(PC pc)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(pc.Name);
            Title.Inlines.Add(underline);
            Price.Text = pc.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(pc.Image));

            DataContext = new PC_ViewModel(pc);
        }*/

        public ViewItemConfigPage(PowerUnit powerUnit)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(powerUnit.Name);
            Title.Inlines.Add(underline);
            Price.Text = powerUnit.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(powerUnit.Image));

            if (PC_ConfigBuilder.pc.PowerUnit != null)
            {
                if (powerUnit.Id == PC_ConfigBuilder.pc.PowerUnit.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new PowerUnit_ViewModel(powerUnit);

            SendObject = powerUnit;
        }

        public ViewItemConfigPage(RAM ram)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(ram.Name);
            Title.Inlines.Add(underline);
            Price.Text = ram.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(ram.Image));

            if (PC_ConfigBuilder.pc.RAM != null)
            {
                if (ram.Id == PC_ConfigBuilder.pc.RAM.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new RAM_ViewModel(ram);

            SendObject = ram;
        }

        public ViewItemConfigPage(SSD ssd)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(ssd.Name);
            Title.Inlines.Add(underline);
            Price.Text = ssd.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(ssd.Image));

            if (PC_ConfigBuilder.pc.SSD != null)
            {
                if (ssd.Id == PC_ConfigBuilder.pc.SSD.Id)
                {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonChange.Visibility = Visibility.Visible;
                }
                else
                {
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonChange.Visibility = Visibility.Collapsed;
                }
            }

            DataContext = new SSD_ViewModel(ssd);

            SendObject = ssd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PC_ConfigBuilder.AddNewComponent(SendObject);
            ButtonAdd.Visibility = Visibility.Collapsed;
            ButtonChange.Visibility = Visibility.Visible;
            UpdateItesmConfig.Invoke(this, EventArgs.Empty);
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            string sendOjectType = ""; 

            switch (SendObject)
            {
                case CPU:
                    sendOjectType = nameof(EnumConfig.Components.CPU);
                    break;
                case GPU:
                    sendOjectType = nameof(EnumConfig.Components.GPU);
                    break;
                case CoolingSystem:
                    sendOjectType = nameof(EnumConfig.Components.CoolingSystem);
                    break;
                case ComputerCase:
                    sendOjectType = nameof(EnumConfig.Components.ComputerCase);
                    break;
                case Motherboard:
                    sendOjectType = nameof(EnumConfig.Components.MotherBoard);
                    break;
                case PowerUnit:
                    sendOjectType = nameof(EnumConfig.Components.PowerUnit);
                    break;
                case RAM:
                    sendOjectType = nameof(EnumConfig.Components.RAM);
                    break;
                case SSD:
                    sendOjectType = nameof(EnumConfig.Components.SSD);
                    break;
                default:
                    sendOjectType = nameof(EnumConfig.Components.CPU);
                    break;
            }


            ChangeItesmConfig.Invoke(sendOjectType, EventArgs.Empty);
        }
    }
}
