using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace artTech.Commands
{
    public static class ViewCatalogItem
    {
        public static void ViewCatalogItems(string? search, int id, string name, string img, decimal price, ItemsControl? catalog, RoutedEventHandler? itemButtonClickHandler)
        {
            if (name.Contains(search))
            {
                DropShadowEffect shadowEffect = new DropShadowEffect();
                shadowEffect.Color = Colors.LightGray; // Цвет тени
                shadowEffect.Direction = 0; // Направление тени
                shadowEffect.ShadowDepth = 0; // Глубина тени
                shadowEffect.BlurRadius = 7; // Радиус размытия
                shadowEffect.RenderingBias = RenderingBias.Performance;

                Border shadowBorder = new Border();
                shadowBorder.BorderThickness = new Thickness(0);
                shadowBorder.CornerRadius = new CornerRadius(3); // Округление углов
                shadowBorder.Background = Brushes.White;
                shadowBorder.Effect = shadowEffect;

                Grid grid = new Grid();
                grid.Height = 250;
                grid.Width = 170;
                grid.HorizontalAlignment = HorizontalAlignment.Center;
                grid.VerticalAlignment = VerticalAlignment.Center;

                Image image = new Image();
                image.Source = new BitmapImage(new Uri(img));
                image.Width = 160;
                image.Margin = new Thickness(0, 0, 0, 20);
                image.VerticalAlignment = VerticalAlignment.Center;

                Grid gridImage = new Grid();
                gridImage.Children.Add(image);
                grid.Height = 250;

                TextBlock nameInfo = new TextBlock();
                nameInfo.Text = name;
                nameInfo.FontSize = 18;
                nameInfo.Foreground = new SolidColorBrush(Colors.Black);
                nameInfo.HorizontalAlignment = HorizontalAlignment.Left;
                nameInfo.VerticalAlignment = VerticalAlignment.Bottom;
                nameInfo.Margin = new Thickness(10, 0, 5, 0);
                nameInfo.TextWrapping = TextWrapping.Wrap;

                TextBlock priceInfo = new TextBlock();
                priceInfo.Text = price.ToString() + " $";
                priceInfo.FontSize = 16;
                priceInfo.Foreground = new SolidColorBrush(Colors.Black);
                priceInfo.HorizontalAlignment = HorizontalAlignment.Right;
                priceInfo.VerticalAlignment = VerticalAlignment.Bottom;
                priceInfo.Margin = new Thickness(0, 0, 5, 15);

                StackPanel info = new StackPanel();
                info.Width = 170;
                info.HorizontalAlignment = HorizontalAlignment.Center;
                info.VerticalAlignment = VerticalAlignment.Bottom;
                info.Background = Brushes.White;

                Button button = new Button();
                button.Name = "ProductItem_" + id;
                button.Height = 250;
                button.Width = 222;
                button.Margin = new Thickness(0, 10, 0, 20);
                button.Padding = new Thickness(10);
                button.Style = (Style)Application.Current.Resources["FlatButtonDesign_RegularStyle"];
                button.Click += itemButtonClickHandler;


                DoubleAnimation scaleAnimation = new DoubleAnimation();
                scaleAnimation.From = 1.0; // начальный размер
                scaleAnimation.To = 1.02; // конечный размер
                scaleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.4)); // продолжительность анимации
                scaleAnimation.AccelerationRatio = 0.10; // 20% ускорения в начале
                scaleAnimation.DecelerationRatio = 0.90; // 80% замедления в конце

                ScaleTransform scaleTransform = new ScaleTransform();
                shadowBorder.RenderTransformOrigin = new Point(0.5, 0.5); // устанавливаем центр масштабирования
                shadowBorder.RenderTransform = scaleTransform;

                button.MouseEnter += (sender, e) =>
                {
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
                };

                button.MouseLeave += (sender, e) =>
                {
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, null); // Отменяем анимацию
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, null); // Отменяем анимацию
                    scaleTransform.ScaleX = 1.0; // Возвращаем начальный размер
                    scaleTransform.ScaleY = 1.0; // Возвращаем начальный размер
                };

                info.Children.Add(nameInfo);
                info.Children.Add(priceInfo);

                grid.Children.Add(gridImage);
                grid.Children.Add(info);

                shadowBorder.Child = grid;

                button.Content = shadowBorder;
                catalog.Items.Add(button);
            }
        }

    }
}
