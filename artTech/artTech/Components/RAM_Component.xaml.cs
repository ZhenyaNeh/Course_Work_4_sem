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
    /// Interaction logic for RAM_Component.xaml
    /// </summary>
    public partial class RAM_Component : UserControl
    {
        public RAM_Component()
        {
            InitializeComponent();
            AddItemPage.CheckRAM += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckMemoryType();
            CheckCountOfSticks();
            CheckOverallVolume();
            CheckFrequency();
        }

        private void CheckMemoryType()
        {
            if (MemoryType.Text.Length > 0 && MemoryType.Text.Length < 100 && MemoryType.Text != string.Empty)
            {
                MemoryType.Foreground = Brushes.Black;
                if (Item_Creator.RAM != null)
                    Item_Creator.RAM.RAM_MemoryType = MemoryType.Text;
            }
            else
            {
                MemoryType.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.RAM != null)
                    Item_Creator.RAM.RAM_MemoryType = "";
            }
        }

        private void CheckCountOfSticks()
        {
            if (int.TryParse(CountOfSticks.Text, out int number))
            {
                if (number >= 2 && number <= 4)
                {
                    CountOfSticks.Foreground = Brushes.Black;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_CountOfSticks = number;
                }
                else
                {
                    CountOfSticks.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_CountOfSticks = 0;
                }
            }
            else
            {
                CountOfSticks.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckOverallVolume()
        {
            if (int.TryParse(OverallVolume.Text, out int number))
            {
                if (number >= 8 && number <= 128)
                {
                    OverallVolume.Foreground = Brushes.Black;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_OverallVolume = number;
                }
                else
                {
                    OverallVolume.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_OverallVolume = 0;
                }
            }
            else
            {
                OverallVolume.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckFrequency()
        {
            if (int.TryParse(Frequency.Text, out int number))
            {
                if (number >= 2400 && number <= 6200)
                {
                    Frequency.Foreground = Brushes.Black;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_Frequency = number;
                }
                else
                {
                    Frequency.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.RAM != null)
                        Item_Creator.RAM.RAM_Frequency = 0;
                }
            }
            else
            {
                Frequency.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void MemoryType_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMemoryType();
        }

        private void CountOfSticks_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCountOfSticks();
        }

        private void OverallVolume_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckOverallVolume();
        }

        private void Frequency_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckFrequency();
        }
    }
}
