using artTech.Controll;
using artTech.Pages;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace artTech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand SearchCommandEvent { get; }

        static bool checkLanguageActivity = false;
        
        public Catalog catalogPage;

        public MainWindow()
        {
            InitializeComponent();
            AddItemPage.LoadHome += LoadedHomePage;
            Account_Control.LoadHomePage += LoadedHomePage;
            artTech.Pages.Configurator.LoadHomePage += LoadedHomePage;
            UserPage.LoadHomePage += LoadedHomePage;
            AdminPage.LoadHomePage += LoadedHomePage;
            App.LanguageChanged += LanguageChanged;
            /*ProductShowcase.CreatorItemsChanged += ChangeItomVisibiliti;
            SearchCommandEvent = new SearchCommand();*/
            CultureInfo currLang = App.Language;
            catalogPage = new Catalog(true);
        }

        private void BackOnHome()
        {
            MainFrame.Content = new HomePage();
            PC_ConfigBuilder.pc = new Models.PC();
            Item_Creator.Crear();

            if (Account_Control.CurrentUserSignIn)
            {
                if (Account_Control.CurrentUserIsAdmin)
                {
                    AddNewItem.Visibility = Visibility.Visible;
                    LogInButton.Content = Account_Control.CurrentAdmin.Name;
                }
                else
                {
                    AddNewItem.Visibility = Visibility.Collapsed;
                    LogInButton.Content = Account_Control.CurrentUser.Name;
                }
            }
            else
            {
                AddNewItem.Visibility = Visibility.Collapsed;
                LogInButton.Content = "Log In or Register";
            }

        }

        private void LoadedHomePage(Object sender, EventArgs e)
        {
            BackOnHome();
        }

        private void ChangeItomVisibiliti(Object sender, EventArgs e)
        {
            /* if (CreatorItems.CurrentUserName != null)
                 RegistrationButton.Content = CreatorItems.CurrentUserName;

             if (CreatorItems.CurrentUser == true)
                 AddNewItem.Visibility = Visibility.Hidden;
             else
                 AddNewItem.Visibility = Visibility.Visible;*/
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
        }

        private void LinkToVK_MouseDown(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/evgeshanex") { UseShellExecute = true });
        }

        private void VisibleLenguageSetting()
        {
            checkLanguageActivity = true;
            ru_Language.Visibility = Visibility.Visible;
            en_Language.Visibility = Visibility.Visible;
            LanguageID.Text = LanguageID.Text.Replace('▾', '▴');
        }

        private void HideLenguageSetting()
        {
            checkLanguageActivity = false;
            ru_Language.Visibility = Visibility.Hidden;
            en_Language.Visibility = Visibility.Hidden;
            LanguageID.Text = LanguageID.Text.Replace('▴', '▾');
        }

        private void LanguageSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!checkLanguageActivity)
            {
                VisibleLenguageSetting();
                return;
            }

            HideLenguageSetting();
            return;
        }

        private void ru_Language_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Language = new CultureInfo("ru-RU");

            Language.Margin = new Thickness(20, 15, 0, 0);
            LanguageID.Margin = new Thickness(0, 15, 20, 0);
            LanguageChoise.Width = 140;

            ru_Language.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C83B1D"));
            en_Language.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));

            LanguageID.Text = "(RU)▾";

            HideLenguageSetting();
        }

        private void en_Language_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Language = new CultureInfo("en-US");

            Language.Margin = new Thickness(0, 15, 0, 0);
            LanguageID.Margin = new Thickness(0, 15, 0, 0);
            LanguageChoise.Width = 120;

            ru_Language.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            en_Language.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C83B1D"));

            LanguageID.Text = "(EN)▾";

            HideLenguageSetting();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Account_Control.CurrentUserSignIn)
                MainFrame.Content = new LogInPage();
            else
            {
                if (Account_Control.CurrentUserIsAdmin)
                {
                    MainFrame.Content = new AdminPage();
                }
                else
                {
                    UserPage userPage = new UserPage();
                    userPage.Name.Text = Account_Control.CurrentUser.Name;
                    userPage.Email.Text = Account_Control.CurrentUser.Email;
                    MainFrame.Content = userPage;
                }
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*WorkWithFille.Serialize(CreatorItems.list_PC, path_Prod);
            WorkWithFille.Serialize(CreatorItems.list_Admin, path_Admin);
            WorkWithFille.Serialize(CreatorItems.list_User, path_User);*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackOnHome();
            //MainFrame.Content = new HomePage();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            catalogPage.CreatorItemsProduct(Search.Text);
            MainFrame.Content = catalogPage;
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary day = new ResourceDictionary();
            ResourceDictionary night = new ResourceDictionary();
            //Resources/Theme/StyleDayTheme.xaml
            day.Source = new Uri("Resources/Theme/StyleDayTheme.xaml", UriKind.Relative);
            night.Source = new Uri("Resources/Theme/StyleNightTheme.xaml", UriKind.Relative);

            ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                          where d.Source != null && d.Source.OriginalString.StartsWith("Resources/Theme/Style")
                                          select d).First();

            if (Theme.IsChecked == true)
            {
                int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, night);
            }
            else
            {
                int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, day);
            }


            /*if (MainFrame.Content is ProductShowcase)
            {
                ProductShowcase productShowcase = new ProductShowcase();
                productShowcase.CreatorItemsProduct("", "");
                MainFrame.Content = productShowcase;
            }*/
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = "";
            catalogPage.CreatorItemsProduct("");
            MainFrame.Content = catalogPage;
        }

        private void Configurator_Click(object sender, RoutedEventArgs e)
        {
            if (!Account_Control.CurrentUserSignIn)
            {
                Button button = sender as Button;
                if (button != null)
                {
                    ToolTip toolTip = new ToolTip();
                    if (toolTip != null)
                    {
                        toolTip.Content = "You need to log in to your account";
                        toolTip.PlacementTarget = button;
                        toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                        toolTip.IsOpen = true;

                        // Закрытие ToolTip через 2 секунды
                        var timer = new System.Windows.Threading.DispatcherTimer
                        {
                            Interval = TimeSpan.FromSeconds(2)
                        };
                        timer.Tick += (s, args) =>
                        {
                            toolTip.IsOpen = false;
                            timer.Stop();
                        };
                        timer.Start();
                        button.ToolTip = toolTip;
                    }
                }
            }
            else
            {
                MainFrame.Content = new Configurator();
            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddItemPage();
        }

    }
}