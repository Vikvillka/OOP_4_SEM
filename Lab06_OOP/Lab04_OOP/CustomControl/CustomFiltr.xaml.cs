using Lab04_OOP.Commands;
using Lab04_OOP.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Lab04_OOP.CustomControl
{
    /// <summary>
    /// Логика взаимодействия для CustomFiltr.xaml
    /// </summary>
    public partial class CustomFiltr : UserControl
    {

        public CustomFiltr()
        {
            InitializeComponent();
           
        }

        public static readonly DependencyProperty MinPriceProperty =
            DependencyProperty.Register("MinPrice", typeof(double), typeof(CustomFiltr),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnMinPriceChanged),
                    new CoerceValueCallback(CoerceMinPriceValue),
                    true, UpdateSourceTrigger.PropertyChanged));

        public static readonly DependencyProperty MaxPriceProperty =
            DependencyProperty.Register("MaxPrice", typeof(double), typeof(CustomFiltr),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnMaxPriceChanged),
                    new CoerceValueCallback(CoerceMaxPriceValue),
                    true, UpdateSourceTrigger.PropertyChanged));

        private static void OnMinPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomFiltr customFiltr = (CustomFiltr)d;
            double newMinPrice = (double)e.NewValue;

            if (newMinPrice < 0)
            {
                customFiltr.MinPrice = 0;
            }
            else if (newMinPrice > customFiltr.MaxPrice)
            {
                customFiltr.MaxPrice = newMinPrice + 20;
            }
        }

        private static void OnMaxPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomFiltr customFiltr = (CustomFiltr)d;
            double newMaxPrice = (double)e.NewValue;

            if (newMaxPrice < 0)
            {
                customFiltr.MinPrice = 20;
            }
            else if (newMaxPrice < customFiltr.MinPrice)
            {
                if (newMaxPrice > 10)
                {
                    customFiltr.MinPrice = newMaxPrice + 10;
                }
                else
                    customFiltr.MinPrice = 0;
            }
        }

        private static object CoerceMinPriceValue(DependencyObject d, object baseValue)
        { 
            double minValue = (double)baseValue;         
            return minValue;
        }

        private static object CoerceMaxPriceValue(DependencyObject d, object baseValue)
        {
            double maxValue = (double)baseValue;
            return maxValue;
        }

        public double MinPrice
        {
            get { return (double)GetValue(MinPriceProperty); }
            set { SetValue(MinPriceProperty, value); }
        }

        public double MaxPrice
        {
            get { return (double)GetValue(MaxPriceProperty); }
            set { SetValue(MaxPriceProperty, value); }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            double minPrice = MinPrice;
            double maxPrice = MaxPrice;

            ICollectionView view = CollectionViewSource.GetDefaultView(Functions.mainWindow.ProductsDataGrid.ItemsSource);
            view.Filter = (item) =>
            {
                Product product = item as Product;
                return product.Price >= minPrice && product.Price <= maxPrice;
            };
        }
    }
}