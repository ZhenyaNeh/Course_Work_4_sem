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
    /// Interaction logic for PowerUnit_Component.xaml
    /// </summary>
    public partial class PowerUnit_Component : UserControl
    {
        public PowerUnit_Component()
        {
            InitializeComponent();
            AddItemPage.CheckPowerUnit += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckPower();
            CheckPowerUnitFormFactor();
        }

        private void CheckPower()
        {
            if (int.TryParse(Power.Text, out int number))
            {
                if (number > 300 && number < 1200)
                {
                    Power.Foreground = Brushes.Black;
                    if (Item_Creator.PowerUnit != null)
                        Item_Creator.PowerUnit.PowerUnit_Power = number;
                }
                else
                {
                    Power.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.PowerUnit != null)
                        Item_Creator.PowerUnit.PowerUnit_Power = 0;
                }
            }
            else
            {
                Power.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckPowerUnitFormFactor()
        {
            if (PowerUnitFormFactor.Text.Length > 0 && PowerUnitFormFactor.Text.Length < 100 && PowerUnitFormFactor.Text != string.Empty)
            {
                PowerUnitFormFactor.Foreground = Brushes.Black;
                if (Item_Creator.PowerUnit != null)
                    Item_Creator.PowerUnit.PowerUnit_FormFactor = PowerUnitFormFactor.Text;
            }
            else
            {
                PowerUnitFormFactor.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.PowerUnit != null)
                    Item_Creator.PowerUnit.PowerUnit_FormFactor = "";
            }
        }

        private void Power_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPower();
        }

        private void PowerUnitFormFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPowerUnitFormFactor();
        }
    }
}
