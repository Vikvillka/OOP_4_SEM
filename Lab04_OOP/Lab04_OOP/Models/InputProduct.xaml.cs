using Lab04_OOP.Commands;
using Lab04_OOP.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Lab04_OOP.Models
{
    /// <summary>
    /// Логика взаимодействия для InputProduct.xaml
    /// </summary>
    public partial class InputProduct : Window
    {
        private Functions functions;
        private ObservableCollection<Product> Products;
        private string imageUri;
        private int indexSelected;
        private ProductType productType;
       
        private InputProduct()
        {
            InitializeComponent();
            Type_ComboBox.SelectedIndex = 0;
        }

        public InputProduct(ObservableCollection<Product> Products, Functions functions) : this()
        {
            this.Products = Products;
            this.functions = functions;
           
        }
        public void AddBinding()
        {
            AddOrChangeButton.Command = this.CommandBindings[1].Command;
            
        }
        public void ChangeBinding(int index)
        {
            AddOrChangeButton.Command = this.CommandBindings[0].Command;
            indexSelected = index;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
                bool? response = open.ShowDialog();
                if (response.HasValue)
                {
                    if (response.Value == true)
                    {
                        string path = open.FileName;
                        BitmapImage bi3 = new BitmapImage();
                        bi3.BeginInit();
                        bi3.UriSource = new Uri(path);
                        bi3.EndInit();
                        ProductImage.Stretch = Stretch.Fill;
                        ProductImage.Source = bi3;
                        imageUri = path;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка: загрузка изображения");
            }
        }
        private void AddProduct_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (functions.ValidateInputProductAdd(Title_TextBox.Text, Description_TextBox.Text, imageUri, Price_Slider.Text)) { 
                functions.AddToDataGrid(Title_TextBox.Text, Description_TextBox.Text, double.Parse(Price_Slider.Text), imageUri, productType, Products);
            }
            else
                MessageBox.Show("Ошибка ввода, данные не добавлены");
        }

        private void ChangeProductInDataGrid(object sender, ExecutedRoutedEventArgs e)
        {
            if (functions.ValidateInputProduct(Title_TextBox.Text, Description_TextBox.Text, imageUri, Price_Slider.Text)) { 
                functions.ChangeInDataGrid(Title_TextBox.Text, Description_TextBox.Text, double.Parse(Price_Slider.Text), imageUri, productType, Products, indexSelected);
  
            }
            else
                MessageBox.Show("Ошибка ввода, данные не добавлены");
        }

        private void Type_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Type_ComboBox.SelectedIndex == 0)
                productType = ProductType.Red;
            if (Type_ComboBox.SelectedIndex == 1)
                productType = ProductType.White;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}

