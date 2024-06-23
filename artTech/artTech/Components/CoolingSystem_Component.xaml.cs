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
    /// Interaction logic for CoolingSystem_Component.xaml
    /// </summary>
    public partial class CoolingSystem_Component : UserControl
    {
        public CoolingSystem_Component()
        {
            InitializeComponent();
            AddItemPage.CheckCoolingSystem += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckCoolingSysremSocket();
            CheckCoolingSysremTDP();
        }

        private void CheckCoolingSysremSocket()
        {
            List<string> support = CoolingSysremSocket.Text.Replace(" ", "").Split(',').ToList();

            if (support.Count < 2 || support.Last() == "")
            {
                CoolingSysremSocket.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.CoolingSystem != null)
                    Item_Creator.CoolingSystem.CoolingSysrem_Socket = support;
            }
            else
            {
                CoolingSysremSocket.Foreground = Brushes.Black;
                if (Item_Creator.CoolingSystem != null)
                    Item_Creator.CoolingSystem.CoolingSysrem_Socket = support;
            }
        }

        private void CheckCoolingSysremTDP()
        {
            if (int.TryParse(CoolingSysremTDP.Text, out int number))
            {
                if (number > 10 && number < 300)
                {
                    CoolingSysremTDP.Foreground = Brushes.Black;
                    if (Item_Creator.CoolingSystem != null)
                        Item_Creator.CoolingSystem.CoolingSysrem_TDP = number;
                }
                else
                {
                    CoolingSysremTDP.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.CoolingSystem != null)
                        Item_Creator.CoolingSystem.CoolingSysrem_TDP = 0;
                }
            }
            else
            {
                CoolingSysremTDP.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CoolingSysremSocket_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCoolingSysremSocket();
        }

        private void CoolingSysremTDP_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCoolingSysremTDP();
        }
    }
}
