using artTech.Controll;
using artTech.Pages;
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

namespace artTech.Components
{
    /// <summary>
    /// Interaction logic for Computer_Component.xaml
    /// </summary>
    public partial class Computer_Component : UserControl
    {
        public Computer_Component()
        {
            InitializeComponent();
            AddItemPage.CheckComputerCase += CheckingCase;
        }

        private void Checking_Supported_Motherboards()
        {
            List<string> support = Supported_Motherboards.Text.Replace(" ", "").Split(',').ToList();

            if (support.Count < 2 || support.Last() == "")
            {
                Supported_Motherboards.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.ComputerCase != null)
                    Item_Creator.ComputerCase.ComputerCase_SupportedMotherboards = support;
            }
            else
            {
                Supported_Motherboards.Foreground = Brushes.Black;
                if (Item_Creator.ComputerCase != null)
                    Item_Creator.ComputerCase.ComputerCase_SupportedMotherboards = support;
            }
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            Checking_Supported_Motherboards();
        }

        private void Supported_Motherboards_TextChanged(object sender, TextChangedEventArgs e)
        {
            Checking_Supported_Motherboards();
        }
    }
}
