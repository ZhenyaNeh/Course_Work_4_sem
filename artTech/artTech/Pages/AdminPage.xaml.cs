using artTech.Components;
using artTech.Controll;
using artTech.ViewModels;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            UserComponent.UpdateDataContext += Update;

            DataContext = new AdminPage_ViewModel();
        }

        private void Update(Object test, EventArgs e)
        {
            Account_Control.UpdateInformation();
            DataContext = new AdminPage_ViewModel();
        }

        public static event EventHandler LoadHomePage;

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            Account_Control.SignOut();
            LoadHomePage.Invoke(this, EventArgs.Empty);
        }


    }
}
