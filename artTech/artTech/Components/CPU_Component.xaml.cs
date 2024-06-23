using artTech.Controll;
using artTech.Pages;
using artTech.ViewModels;
using System;
using System.Collections.Generic;
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

namespace artTech.Components
{
    /// <summary>
    /// Interaction logic for CPU_Component.xaml
    /// </summary>
    public partial class CPU_Component : UserControl
    {
        public CPU_Component()
        {
            InitializeComponent();
            AddItemPage.CheckCPU += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckCPUManufacturer();
            CheckCPUSocket();
            CheckCPUMemorySuport();
            CheckCPUIntegratedGraphics();
            CheckCPU_TDP();
        }



        private void CheckCPUManufacturer()
        {
            if (CPUManufacturer.Text.Length > 0 && CPUManufacturer.Text.Length < 100 && CPUManufacturer.Text != string.Empty)
            {
                CPUManufacturer.Foreground = Brushes.Black;
                if(Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_Manufacturer = CPUManufacturer.Text;
            }
            else
            {
                CPUManufacturer.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_Manufacturer = "";
            }
        }
        
        private void CheckCPUSocket()
        {
            if (CPUSocket.Text.Length > 0 && CPUSocket.Text.Length < 100 && CPUSocket.Text != string.Empty)
            {
                CPUSocket.Foreground = Brushes.Black;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_Socket = CPUSocket.Text;
            }
            else
            {
                CPUSocket.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_Socket = "";
            }
        }

        private void CheckCPUMemorySuport()
        {
            if (CPUMemorySuport.Text.Length > 0 && CPUMemorySuport.Text.Length < 100 && CPUMemorySuport.Text != string.Empty)
            {
                CPUMemorySuport.Foreground = Brushes.Black;
                if (Item_Creator.CPU!= null)
                    Item_Creator.CPU.CPU_MemorySupport = CPUMemorySuport.Text;
            }
            else
            {
                CPUMemorySuport.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_MemorySupport = "";
            }
        }

        private void CheckCPUIntegratedGraphics()
        {
            if (CPUIntegratedGraphics.Text.Length > 0 && CPUIntegratedGraphics.Text.Length < 100 && CPUIntegratedGraphics.Text != string.Empty)
            {
                CPUIntegratedGraphics.Foreground = Brushes.Black;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_IntegratedGraphics = CPUIntegratedGraphics.Text;
            }
            else
            {
                CPUIntegratedGraphics.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.CPU != null)
                    Item_Creator.CPU.CPU_IntegratedGraphics = "";
            }
        }

        private void CheckCPU_TDP()
        {
            if (int.TryParse(CPU_TDP.Text, out int number))
            {
                if (number > 10 && number < 150)
                {
                    CPU_TDP.Foreground = Brushes.Black;
                    if (Item_Creator.CPU != null)
                        Item_Creator.CPU.CPU_TDP = number;
                }
                else
                {
                    CPU_TDP.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.CPU != null)
                        Item_Creator.CPU.CPU_TDP = 0;
                }
            }
            else
            {
                CPU_TDP.Foreground = Brushes.PaleVioletRed;
            }
        }


        private void CPUManufacturer_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPUManufacturer();
        }

        private void CPUSocket_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPUSocket();
        }

        private void CPUMemorySuport_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPUMemorySuport();
        }

        private void CPUIntegratedGraphics_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPUIntegratedGraphics();
        }

        private void CPU_TDP_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPU_TDP();
        }
    }
}
