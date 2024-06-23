using artTech.Controll;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace artTech.Pages
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
            Account_Control.UpdateInformation();
        }

        private void RegistrationPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            var valid = Account_Control.VeritifyLogIn(Login.Text, Password.Password);
            if (!valid)
            {
                Login.Foreground = Brushes.PaleVioletRed;
                Password.Foreground = Brushes.PaleVioletRed;
            }
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            Login.Foreground = Brushes.Black;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Foreground = Brushes.Black;
        }
    }
}
