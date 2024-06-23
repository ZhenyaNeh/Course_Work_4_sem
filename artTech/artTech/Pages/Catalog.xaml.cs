using artTech.Commands;
using artTech.Controll;
using MaterialDesignColors;
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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public BaseCommand ViewPageCommand { get; }
        public BaseCommand ViewPageConfigCommand { get; }
        public BaseCommand ViewSearchCommand { get; }
        public BaseCommand ViewSearchConfigCommand { get; }
        public BaseCommand UserPCCommand { get; }

        private string? FilterInfo { get; set; } = "";
        private string? SearchInfo { get; set; } = "";
        private string? FilterInfoConfig { get; set; } = "";

        public Catalog(bool visblityFiter)
        {
            InitializeComponent();
            ViewPageCommand = new ViewPageItemCommand();
            ViewPageConfigCommand = new ViewItemConfigCommand();
            ViewSearchCommand = new SearchCommand();
            ViewSearchConfigCommand = new SearchConfigCommand();
            UserPCCommand = new ViewUserPCCommand();


            if (visblityFiter)
            {
                FilterBorder.Visibility = Visibility.Visible;
                CatalogScroll.Margin = new Thickness(0, 35, 0, 0);
            }
            else
            {
                FilterBorder.Visibility = Visibility.Collapsed;
                CatalogScroll.Margin = new Thickness(0, 15, 0, 0);
            }

            if (ComparisonModeControl.ComparisonModeIsActive)
            {
                ComparisionMode.Visibility = Visibility.Collapsed;
            }
            else
            {
                FilterBorder.Visibility = Visibility.Visible;
            }
        }

        public void CreatorItemsProduct(string search)
        {
            CatalogArea.Items.Clear();

            SearchInfo = search;

            if (FilterInfo != "")
                ViewSearchCommand.Execute(SearchInfo, FilterInfo, CatalogArea, this.ItemButton_Click);
            else
                ViewSearchCommand.Execute(SearchInfo, "", CatalogArea, this.ItemButton_Click);

        }

        public void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewPageCommand.Execute(sender, FilterInfo, this.NavigationService);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CatalogArea.Items.Clear();

            ComboBox? comboBox = sender as ComboBox;
            ComboBoxItem? boxItem = comboBox?.SelectedItem as ComboBoxItem;

            if (ComparisonModeControl.ComparisonModeIsActive)
            {
                if (boxItem != null)
                {
                    FilterInfo = boxItem.Content.ToString();
                    ViewPageConfigCommand.Execute(SearchInfo, FilterInfo, CatalogArea, this.ItemButton_Click);
                }
            }
            else
            {
                if (boxItem != null)
                {
                    FilterInfo = boxItem.Content.ToString();
                    ViewSearchCommand.Execute(SearchInfo, FilterInfo, CatalogArea, this.ItemButton_Click);
                }
            }
        }

        public void UserItems()
        {
            CatalogArea.Items.Clear();
            UserPCCommand.Execute("", "", CatalogArea, this.UserItems_Click);
        }

        public void UserItems_Click(object sender, RoutedEventArgs e)
        {
            ViewPageCommand.Execute(sender, "PC", this.NavigationService);
        }

        public void CreatorConfigItems(string type)
        {
            CatalogArea.Items.Clear();

            FilterInfoConfig = type;
            ViewSearchConfigCommand.Execute("", type, CatalogArea, this.ItemButtonConfig_Click);
        }


        public void ItemButtonConfig_Click(object sender, RoutedEventArgs e)
        {
            ViewPageConfigCommand.Execute(sender, FilterInfoConfig, this.NavigationService);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ComparisonModeControl.ComparisonModeIsActive = true;
            NavigationService.Navigate(new ComparisonMode());
        }
    }
}
