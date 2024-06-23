using artTech.Controll;
using artTech.Data;
using artTech.Models;
using artTech.Models.Peeson;
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
    /// Interaction logic for ViewItemPage_PC.xaml
    /// </summary>
    public partial class ViewItemPage_PC : Page
    {
        PC CurrentPC { get; set; }


        public ViewItemPage_PC(PC pc)
        {
            InitializeComponent();

            Underline underline = new Underline();
            underline.Inlines.Add(pc.Name);
            Title.Inlines.Add(underline);
            Price.Text = pc.Price.ToString() + "$";

            ImageSrc.Source = new BitmapImage(new Uri(pc.Image));

            CurrentPC = pc;
            DataContext = new PC_ViewModel(pc);
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            Account_Control.CurrentAdmin = Account_Control.Admins.First();

            using (var context = new ConfigPCContext())
            {
                MyRepository<Admin> adminRepositoty = new MyRepository<Admin>(context);


                if (Account_Control.CurrentAdmin.PublishPC == null)
                    Account_Control.CurrentAdmin.PublishPC = new List<PC>();

                Account_Control.CurrentAdmin.PublishPC.Add(CurrentPC);
                adminRepositoty.Update(Account_Control.CurrentAdmin);



            }
            // Account_Control.CurrentAdmin = new Admin();
            PublishButton.Visibility = Visibility.Collapsed;
        }
    }
}
