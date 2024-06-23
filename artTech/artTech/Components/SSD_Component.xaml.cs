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
    /// Interaction logic for SSD_Component.xaml
    /// </summary>
    public partial class SSD_Component : UserControl
    {
        public SSD_Component()
        {
            InitializeComponent();
            AddItemPage.CheckSSD += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckFormFactor();
            CheckSSDSize();
        }

        private void CheckFormFactor()
        {
            if (FormFactor.Text.Length > 0 && FormFactor.Text.Length < 100 && FormFactor.Text != string.Empty)
            {
                FormFactor.Foreground = Brushes.Black;
                if (Item_Creator.SSD != null)
                    Item_Creator.SSD.SSD_FormFactor = FormFactor.Text;
            }
            else
            {
                FormFactor.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.SSD != null)
                    Item_Creator.SSD.SSD_FormFactor = "";
            }
        }

        private void CheckSSDSize()
        {
            if (SSDSize.Text.Length > 0 && SSDSize.Text.Length < 100 && SSDSize.Text != string.Empty)
            {
                SSDSize.Foreground = Brushes.Black;
                if (Item_Creator.SSD != null)
                    Item_Creator.SSD.SSD_Size= SSDSize.Text;
            }
            else
            {
                SSDSize.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.SSD != null)
                    Item_Creator.SSD.SSD_Size = "";
            }
        }

        private void FormFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckFormFactor();
        }

        private void SSDSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSSDSize();
        }
    }
}
