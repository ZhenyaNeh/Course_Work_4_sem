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
    /// Interaction logic for GPU_Component.xaml
    /// </summary>
    public partial class GPU_Component : UserControl
    {
        public GPU_Component()
        {
            InitializeComponent();
            AddItemPage.CheckGPU += CheckingCase;
        }

        private void CheckingCase(Object sender, EventArgs e)
        {
            CheckGPUManufacturer();
            CheckGPUMemorySuport();
            CheckCPURecommendedPowerSupply();
        }

        private void CheckGPUManufacturer()
        {
            if (GPUManufacturer.Text.Length > 0 && GPUManufacturer.Text.Length < 100 && GPUManufacturer.Text != string.Empty)
            {
                GPUManufacturer.Foreground = Brushes.Black;
                if (Item_Creator.GPU != null)
                    Item_Creator.GPU.GPU_Manufacturer = GPUManufacturer.Text;
            }
            else
            {
                GPUManufacturer.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.GPU != null)
                    Item_Creator.GPU.GPU_Manufacturer = "";
            }
        }

        private void CheckGPUMemorySuport()
        {
            if (GPUMemorySuport.Text.Length > 0 && GPUMemorySuport.Text.Length < 100 && GPUMemorySuport.Text != string.Empty)
            {
                GPUMemorySuport.Foreground = Brushes.Black;
                if (Item_Creator.GPU != null)
                    Item_Creator.GPU.GPU_MemorySupport = GPUMemorySuport.Text;
            }
            else
            {
                GPUMemorySuport.Foreground = Brushes.PaleVioletRed;
                if (Item_Creator.GPU != null)
                    Item_Creator.GPU.GPU_MemorySupport = "";
            }
        }

        private void CheckCPURecommendedPowerSupply()
        {
            if (int.TryParse(GPURecommendedPowerSupply.Text, out int number))
            {
                if (number > 300 && number < 1200)
                {
                    GPURecommendedPowerSupply.Foreground = Brushes.Black;
                    if (Item_Creator.GPU != null)
                        Item_Creator.GPU.GPU_RecommendedPowerSupply = number;
                }
                else
                {
                    GPURecommendedPowerSupply.Foreground = Brushes.PaleVioletRed;
                    if (Item_Creator.GPU != null)
                        Item_Creator.GPU.GPU_RecommendedPowerSupply = 0;
                }
            }
            else
            {
                GPURecommendedPowerSupply.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void GPUManufacturer_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckGPUManufacturer();
        }

        private void GPUMemorySuport_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckGPUMemorySuport();
        }

        private void CPURecommendedPowerSupply_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckCPURecommendedPowerSupply();
        }
    }
}
