using artTech.Commands;
using artTech.Controll;
using artTech.Data;
using artTech.Data.UnitOfWork;
using artTech.Models;
using artTech.Models.Peeson;
using artTech.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
    /// Interaction logic for ViewItemPage.xaml
    /// </summary>
    public partial class ViewItemPage : Page
    {
        

        public object SendObject { get; set; }

        public ViewItemPage(CPU cpu)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(cpu.Name);
            Title.Inlines.Add(underline);
            Price.Text = cpu.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(cpu.Image));

            DataContext = new CPU_ViewModel(cpu);
            SendObject = cpu;
        }

        public ViewItemPage(GPU gpu)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(gpu.Name);
            Title.Inlines.Add(underline);
            Price.Text = gpu.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(gpu.Image));

            DataContext = new GPU_ViewModel(gpu);
            SendObject = gpu;
        }

        public ViewItemPage(ComputerCase computerCase)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(computerCase.Name);
            Title.Inlines.Add(underline);
            Price.Text = computerCase.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(computerCase.Image));

            DataContext = new ComputerCase_ViewModel(computerCase);
            SendObject = computerCase;
        }

        public ViewItemPage(CoolingSystem coolingSystem)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(coolingSystem.Name);
            Title.Inlines.Add(underline);
            Price.Text = coolingSystem.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(coolingSystem.Image));

            DataContext = new CoolingSystem_ViewModel(coolingSystem);
            SendObject = coolingSystem;
        }

        public ViewItemPage(Motherboard motherboard)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(motherboard.Name);
            Title.Inlines.Add(underline);
            Price.Text = motherboard.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(motherboard.Image));

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

        public ViewItemPage(PowerUnit powerUnit)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(powerUnit.Name);
            Title.Inlines.Add(underline);
            Price.Text = powerUnit.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(powerUnit.Image));

            DataContext = new PowerUnit_ViewModel(powerUnit);
            SendObject = powerUnit;
        }

        public ViewItemPage(RAM ram)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(ram.Name);
            Title.Inlines.Add(underline);
            Price.Text = ram.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(ram.Image));

            DataContext = new RAM_ViewModel(ram);
            SendObject = ram;
        }

        public ViewItemPage(SSD ssd)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(ssd.Name);
            Title.Inlines.Add(underline);
            Price.Text = ssd.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(ssd.Image));

            DataContext = new SSD_ViewModel(ssd);
            SendObject = ssd;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Account_Control.CurrentUserSignIn)
            {
                if (!Account_Control.CurrentUserIsAdmin)
                {
                    using (var context = new ConfigPCContext())
                    {
                        MyRepository<GPU> gpuRepositoty = new MyRepository<GPU>(new ConfigPCContext());
                        MyRepository<Motherboard> motherboardRepositoty = new MyRepository<Motherboard>(new ConfigPCContext());
                        MyRepository<RAM> ramRepositoty = new MyRepository<RAM>(new ConfigPCContext());
                        MyRepository<SSD> ssdRepositoty = new MyRepository<SSD>(new ConfigPCContext());
                        MyRepository<CPU> cpuRepositoty = new MyRepository<CPU>(new ConfigPCContext());
                        MyRepository<CoolingSystem> coolingSystemRepositoty = new MyRepository<CoolingSystem>(new ConfigPCContext());
                        MyRepository<PowerUnit> powerUnitRepositoty = new MyRepository<PowerUnit>(new ConfigPCContext());
                        MyRepository<ComputerCase> computerCaseRepositoty = new MyRepository<ComputerCase>(new ConfigPCContext());

                        Comment comment = new Comment();
                        comment.CommentString = CommentText.Text.Trim().ToString();
                        comment.NamePerson = Account_Control.CurrentUser.Name.ToString();

                        CommentText.Text = "";

                        switch (SendObject)
                        {
                            case CPU cpu:
                                if (cpu.Comments == null)
                                    cpu.Comments = new List<Comment>();

                                cpu.Comments.Add(comment);
                                cpuRepositoty.Update(cpu);

                                DataContext = new CPU_ViewModel(cpu);

                                break;
                            case GPU gpu:
                                if (gpu.Comments == null)
                                    gpu.Comments = new List<Comment>();

                                gpu.Comments.Add(comment);
                                gpuRepositoty.Update(gpu);

                                DataContext = new GPU_ViewModel(gpu);

                                break;
                            case CoolingSystem coolingSystem:
                                if (coolingSystem.Comments == null)
                                    coolingSystem.Comments = new List<Comment>();

                                coolingSystem.Comments.Add(comment);
                                coolingSystemRepositoty.Update(coolingSystem);

                                DataContext = new CoolingSystem_ViewModel(coolingSystem);

                                break;
                            case ComputerCase computerCase:
                                if (computerCase.Comments == null)
                                    computerCase.Comments = new List<Comment>();

                                computerCase.Comments.Add(comment);
                                computerCaseRepositoty.Update(computerCase);

                                DataContext = new ComputerCase_ViewModel(computerCase);

                                break;
                            case Motherboard motherboard:
                                if (motherboard.Comments == null)
                                    motherboard.Comments = new List<Comment>();

                                motherboard.Comments.Add(comment);
                                motherboardRepositoty.Update(motherboard);

                                DataContext = new Motherboard_ViewModel(motherboard);

                                break;
                            case PowerUnit powerUnit:
                                if (powerUnit.Comments == null)
                                    powerUnit.Comments = new List<Comment>();

                                powerUnit.Comments.Add(comment);
                                powerUnitRepositoty.Update(powerUnit);

                                DataContext = new PowerUnit_ViewModel(powerUnit);

                                break;
                            case RAM ram:
                                if (ram.Comments == null)
                                    ram.Comments = new List<Comment>();

                                ram.Comments.Add(comment);
                                ramRepositoty.Update(ram);

                                DataContext = new RAM_ViewModel(ram);

                                break;
                            case SSD ssd:
                                if (ssd.Comments == null)
                                    ssd.Comments = new List<Comment>();

                                ssd.Comments.Add(comment);
                                ssdRepositoty.Update(ssd);

                                DataContext = new SSD_ViewModel(ssd);

                                break;
                            default:

                                break;
                        }
                    }
                }
            }
            else
            {
                Button button = sender as Button;
                if (button != null)
                {
                    ToolTip toolTip = new ToolTip();
                    if (toolTip != null)
                    {
                        toolTip.Content = "You need to log in to your account";
                        toolTip.PlacementTarget = button;
                        toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                        toolTip.IsOpen = true;

                        // Закрытие ToolTip через 2 секунды
                        var timer = new System.Windows.Threading.DispatcherTimer
                        {
                            Interval = TimeSpan.FromSeconds(2)
                        };
                        timer.Tick += (s, args) =>
                        {
                            toolTip.IsOpen = false;
                            timer.Stop();
                        };
                        timer.Start();
                        button.ToolTip = toolTip;
                    }
                }
            }
        }
    }
}
