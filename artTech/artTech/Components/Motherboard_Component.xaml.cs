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
    /// Interaction logic for Motherboard_Component.xaml
    /// </summary>
    public partial class Motherboard_Component : UserControl
    {
        public Motherboard_Component()
        {
            InitializeComponent();
            AddItemPage.CheckMotherboard += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckMotherboardCPUSpport();
            CheckMotherboardSocket();
            CheckMotherboardFormFactor();
            CheckMotherboardMemorySupport();
            CheckNumberOfRAMSlots();
            CheckMaximumRAMCapacity();
            CheckMaximumRAMFrequency();
            CheckNumberOfM2Slots();
            CheckNumberOfSATA3Slots();
        }

        private void CheckMotherboardCPUSpport()
        {
            if (MotherboardCPUSpport.Text.Length > 0 && MotherboardCPUSpport.Text.Length < 100 && MotherboardCPUSpport.Text != string.Empty)
            {
                MotherboardCPUSpport.Foreground = Brushes.Black;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_CPU_Spport = MotherboardCPUSpport.Text;
            }
            else
            {
                MotherboardCPUSpport.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_CPU_Spport = "";
            }
        }
        private void CheckMotherboardSocket()
        {
            if (MotherboardSocket.Text.Length > 0 && MotherboardSocket.Text.Length < 100 && MotherboardSocket.Text != string.Empty)
            {
                MotherboardSocket.Foreground = Brushes.Black;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_Socket = MotherboardSocket.Text;
            }
            else
            {
                MotherboardSocket.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_Socket= "";
            }
        }

        private void CheckMotherboardFormFactor()
        {
            if (MotherboardFormFactor.Text.Length > 0 && MotherboardFormFactor.Text.Length < 100 && MotherboardFormFactor.Text != string.Empty)
            {
                MotherboardFormFactor.Foreground = Brushes.Black;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_FormFactor= MotherboardFormFactor.Text;
            }
            else
            {
                MotherboardFormFactor.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_FormFactor= "";
            }
        }

        private void CheckMotherboardMemorySupport()
        {
            if (MotherboardMemorySupport.Text.Length > 0 && MotherboardMemorySupport.Text.Length < 100 && MotherboardMemorySupport.Text != string.Empty)
            {
                MotherboardMemorySupport.Foreground = Brushes.Black;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_MemorySupport= MotherboardMemorySupport.Text;
            }
            else
            {
                MotherboardMemorySupport.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.Motherboard != null)
                    Item_Creator.Motherboard.Motherboard_MemorySupport= "";
            }
        }

        private void CheckNumberOfRAMSlots()
        {
            if (int.TryParse(NumberOfRAMSlots.Text, out int number))
            {
                if (number >= 2 && number <= 4)
                {
                    NumberOfRAMSlots.Foreground = Brushes.Black;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_RAM_Slots = number;
                }
                else
                {
                    NumberOfRAMSlots.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_RAM_Slots = 0;
                }
            }
            else
            {
                NumberOfRAMSlots.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckMaximumRAMCapacity()
        {
            if (int.TryParse(MaximumRAMCapacity.Text, out int number))
            {
                if (number >= 8 && number <= 128)
                {
                    MaximumRAMCapacity.Foreground = Brushes.Black;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_Maximum_RAM_Capacity= number;
                }
                else
                {
                    MaximumRAMCapacity.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_Maximum_RAM_Capacity = 0;
                }
            }
            else
            {
                MaximumRAMCapacity.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckMaximumRAMFrequency()
        {
            if (int.TryParse(MaximumRAMFrequency.Text, out int number))
            {
                if (number > 2400 && number < 6200)
                {
                    MaximumRAMFrequency.Foreground = Brushes.Black;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_Maximum_RAM_Frequency = number;
                }
                else
                {
                    MaximumRAMFrequency.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_Maximum_RAM_Frequency = 0;
                }
            }
            else
            {
                MaximumRAMFrequency.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckNumberOfM2Slots()
        {
            if (int.TryParse(NumberOfM2Slots.Text, out int number))
            {
                if (number >= 0 && number < 6)
                {
                    NumberOfM2Slots.Foreground = Brushes.Black;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_M2_Slots = number;
                }
                else
                {
                    NumberOfM2Slots.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_M2_Slots= 0;
                }
            }
            else
            {
                NumberOfM2Slots.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void CheckNumberOfSATA3Slots()
        {
            if (int.TryParse(NumberOfSATA3Slots.Text, out int number))
            {
                if (number > 0 && number < 4)
                {
                    NumberOfSATA3Slots.Foreground = Brushes.Black;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_SATA3_Slots = number;
                }
                else
                {
                    NumberOfSATA3Slots.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.Motherboard != null)
                        Item_Creator.Motherboard.Motherboard_NumberOf_SATA3_Slots = 0;
                }
            }
            else
            {
                NumberOfSATA3Slots.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void MotherboardCPUSpport_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMotherboardCPUSpport();
        }

        private void MotherboardSocket_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMotherboardSocket();
        }

        private void MotherboardFormFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMotherboardFormFactor();
        }

        private void MotherboardMemorySupport_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMotherboardMemorySupport();
        }

        private void NumberOfRAMSlots_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNumberOfRAMSlots();
        }

        private void MaximumRAMCapacity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMaximumRAMCapacity();
        }

        private void MaximumRAMFrequency_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckMaximumRAMFrequency();
        }

        private void NumberOfM2Slots_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNumberOfM2Slots();
        }

        private void NumberOfSATA3Slots_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNumberOfSATA3Slots();
        }
    }
}
