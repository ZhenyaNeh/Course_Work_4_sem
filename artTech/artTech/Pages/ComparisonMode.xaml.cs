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

namespace artTech.Pages
{
    /// <summary>
    /// Interaction logic for ComparisonMode.xaml
    /// </summary>
    public partial class ComparisonMode : Page
    {
        public ComparisonMode()
        {
            InitializeComponent();
            Catalog catalogLeft = new Catalog(true);
            catalogLeft.CreatorConfigItems("CPU");
            Catalog catalogRight = new Catalog(true);
            catalogRight.CreatorConfigItems("CPU");
            LeftFrame.Content = catalogLeft;
            RightFrame.Content = catalogRight;
        }
    }
}
