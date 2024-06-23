using artTech.Commands;
using artTech.Components;
using artTech.Controll;
using artTech.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        public static event EventHandler CheckCPU;
        public static event EventHandler CheckGPU;
        public static event EventHandler CheckRAM;
        public static event EventHandler CheckSSD;
        public static event EventHandler CheckMotherboard;
        public static event EventHandler CheckCoolingSystem;
        public static event EventHandler CheckPowerUnit;
        public static event EventHandler CheckComputerCase;


        public static event EventHandler LoadHome;

        public object CurrentObj {  get; set; }

        private string Img {  get; set; } = string.Empty;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox? comboBox = sender as System.Windows.Controls.ComboBox;
            ComboBoxItem? boxItem = comboBox?.SelectedItem as ComboBoxItem;

            Item_Creator.Crear(); 

            switch (boxItem.Content.ToString())
            {
                case nameof(EnumConfig.Components.CPU):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new CPU_Component());
                    CurrentObj = new CPU();

                    break;
                case nameof(EnumConfig.Components.GPU):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new GPU_Component());
                    CurrentObj = new GPU();

                    break;
                case nameof(EnumConfig.Components.MotherBoard):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new Motherboard_Component());
                    CurrentObj = new Motherboard();

                    break;
                case nameof(EnumConfig.Components.RAM):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new RAM_Component());
                    CurrentObj = new RAM();

                    break;
                case nameof(EnumConfig.Components.SSD):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new SSD_Component());
                    CurrentObj = new SSD();

                    break;
                case nameof(EnumConfig.Components.CoolingSystem):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new CoolingSystem_Component());
                    CurrentObj = new CoolingSystem();

                    break;
                case nameof(EnumConfig.Components.PowerUnit):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new PowerUnit_Component());
                    CurrentObj = new PowerUnit();

                    break;
                case nameof(EnumConfig.Components.ComputerCase):
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new Computer_Component());
                    CurrentObj = new ComputerCase();

                    break;
                default:
                    FillArea.Items.Clear();
                    FillArea.Items.Add(new CPU_Component());
                    CurrentObj = new CPU();

                    break;
            }
        }

        private void ImageSrc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var filePicker = new OpenFileDialog();

            filePicker.DefaultExt = ".jpg";
            filePicker.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";

            bool? result = filePicker.ShowDialog();

            if (result == true)
            {
                string filePath = filePicker.FileName;
                string[] parts = filePath.Split('\\');
                string fileName = parts[parts.Length - 1];

                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                try
                {
                    File.Copy(filePath, projectPath + "/Resources/Image/" + fileName, true);
                }
                catch { }

                var source = new BitmapImage(new Uri(projectPath + "/Resources/Image/" + fileName));

                ImageSrc.Source = source;
                Img = projectPath + "/Resources/Image/" + fileName;
            }
        }

        private void SaveInfoItem()
        {
            string name = Title.Text;
            string img = ImageSrc.Source.ToString();
            decimal.TryParse(Price.Text, out decimal price);

            switch (CurrentObj)
            {
                case CPU:
                    if(Item_Creator.CPU != null)
                    {
                        Item_Creator.CPU.Name = name;
                        Item_Creator.CPU.Image = img;
                        Item_Creator.CPU.Price = price;
                    }
                    if(!Item_Creator.CheckingCPU())
                        CheckCPU.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case GPU:
                    if (Item_Creator.GPU != null)
                    {
                        Item_Creator.GPU.Name = name;
                        Item_Creator.GPU.Image = img;
                        Item_Creator.GPU.Price = price;
                    }
                    if (!Item_Creator.CheckingGPU())
                        CheckGPU.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case CoolingSystem:
                    if (Item_Creator.CoolingSystem != null)
                    {
                        Item_Creator.CoolingSystem.Name = name;
                        Item_Creator.CoolingSystem.Image = img;
                        Item_Creator.CoolingSystem.Price = price;
                    }
                    if (!Item_Creator.CheckingCoolingSystem())
                        CheckCoolingSystem.Invoke(this, EventArgs.Empty);
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case ComputerCase:
                    if (Item_Creator.ComputerCase != null)
                    {
                        Item_Creator.ComputerCase.Name = name;
                        Item_Creator.ComputerCase.Image = img;
                        Item_Creator.ComputerCase.Price = price;
                    }
                    if(!Item_Creator.CheckingComputerCase())
                        CheckComputerCase.Invoke(this, EventArgs.Empty);
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case Motherboard:
                    if (Item_Creator.Motherboard != null)
                    {
                        Item_Creator.Motherboard.Name = name;
                        Item_Creator.Motherboard.Image = img;
                        Item_Creator.Motherboard.Price = price;
                    }
                    if (!Item_Creator.CheckingMotherboard())
                        CheckMotherboard.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case PowerUnit:
                    if (Item_Creator.PowerUnit != null)
                    {
                        Item_Creator.PowerUnit.Name = name;
                        Item_Creator.PowerUnit.Image = img;
                        Item_Creator.PowerUnit.Price = price;
                    }
                    if (!Item_Creator.CheckingPowerUnit())
                        CheckPowerUnit.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case RAM:
                    if (Item_Creator.RAM != null)
                    {
                        Item_Creator.RAM.Name = name;
                        Item_Creator.RAM.Image = img;
                        Item_Creator.RAM.Price = price;
                    }
                    if (!Item_Creator.CheckingRAM())
                        CheckRAM.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                case SSD:
                    if (Item_Creator.SSD != null)
                    {
                        Item_Creator.SSD.Name = name;
                        Item_Creator.SSD.Image = img;
                        Item_Creator.SSD.Price = price;
                    }
                    if (!Item_Creator.CheckingSSD())
                        CheckSSD.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
                default:
                    if (Item_Creator.CPU != null)
                    {
                        Item_Creator.CPU.Name = name;
                        Item_Creator.CPU.Image = img;
                        Item_Creator.CPU.Price = price;
                    }
                    if (!Item_Creator.CheckingCPU())
                        CheckCPU.Invoke(this, new EventArgs());
                    else
                        LoadHome.Invoke(this, new EventArgs());

                    break;
            }
        }

        private void ChackingTitle()
        {
            if (Title.Text.Length > 3 && Title.Text.Length < 100 && Title.Text != string.Empty)
            {
                Title.Foreground = Brushes.Black;
            }
            else
            {
                Title.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void ChackingPrice()
        {
            if (decimal.TryParse(Price.Text, out decimal number))
            {
                if (number > 0 && number < 10_000)
                {
                    Price.Foreground = Brushes.Black;
                }
                else
                {
                    Price.Foreground = Brushes.PaleVioletRed;
                }
            }
            else
            {
                Price.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChackingTitle();
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
           ChackingPrice();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ChackingTitle();
            ChackingPrice();

            if(Title.Background != Brushes.PaleVioletRed &&
               Price.Background != Brushes.PaleVioletRed &&
               Img != string.Empty)
            {
                SaveInfoItem();
            }
            else
            {

            }


        }
    }
}
