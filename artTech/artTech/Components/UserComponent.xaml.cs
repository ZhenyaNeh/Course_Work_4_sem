using artTech.Data;
using artTech.Data.UnitOfWork;
using artTech.Models.Peeson;
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
    /// Interaction logic for UserComponent.xaml
    /// </summary>
    public partial class UserComponent : UserControl
    {
        public UserComponent()
        {
            InitializeComponent();
        }

        public static event EventHandler UpdateDataContext;

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                var dataContext = this.DataContext as User;

                if (dataContext != null)
                {
                    using (var context = new ConfigPCContext())
                    {
                        MyRepository<User> userRepositoty = new MyRepository<User>(new ConfigPCContext());

                        userRepositoty.Del(dataContext.Id);

                        if (MessageBox.Show("You agree", "Answer", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                            return;
                        userRepositoty.Save();
                    }
                    UpdateDataContext.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
