using artTech.Controll;
using Microsoft.Identity.Client.NativeInterop;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            var cat = new Catalog(false);
            cat.UserItems();
            SaveConfigFrame.Content = cat;
        }

        public static event EventHandler LoadHomePage;

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            Account_Control.SignOut();
            LoadHomePage.Invoke(this, EventArgs.Empty);
        }
    }
}
