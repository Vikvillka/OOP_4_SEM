using Lab04_OOP.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab04_OOP.Memento;
using Lab04_OOP.Commands;
using Lab04_OOP.Models;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;


namespace Lab04_OOP.Commands
{
    public class Functions
    {
        private Caretaker caretaker;
      /*  private AppState appState;*/
        protected internal static MainWindow mainWindow;
        public Functions() { }
        public Functions(MainWindow mainWindow)
        {
            caretaker = new Caretaker();
            /*appState = new AppState();*/
            Functions.mainWindow = mainWindow;
        }


        public void ChangeInDataGrid(string title, string description, double price, string uri, ProductType productType, ObservableCollection<Product> Products, int selectIndex)
        {
            string existingImagePath = Products[selectIndex].Image;
            Products[selectIndex] = new Product()
            {
                Title = title,
                Description = description,
                Price = price,
                Image = existingImagePath,
                Type = productType
            };

            mainWindow.ProductsDataGrid.Items.Refresh();
        }

        public void RemoveDataGridItem(ObservableCollection<Product> Products)
        {
            Guid product_id = (mainWindow.ProductsDataGrid.SelectedItem as Product).ID;
            Product product = (from pr in Products where pr.ID == product_id select pr).SingleOrDefault();
            Products.Remove(product);
            mainWindow.ProductsDataGrid.ItemsSource = Products;
        }

        public void OpenProductForm(ObservableCollection<Product> Products, Functions functions)
        {
            InputProduct inputProduct = new InputProduct(Products, functions);
            inputProduct.Owner = mainWindow;
           
            inputProduct.AddBinding();
            inputProduct.Show();
        }
        public void ChangeProductForm(ObservableCollection<Product> Products, Functions functions)
        {
            InputProduct inputProduct = new InputProduct(Products, functions);
            inputProduct.Owner = mainWindow;

            int selectedIndex = mainWindow.ProductsDataGrid.SelectedIndex;
            Product selectedProduct = mainWindow.ProductsDataGrid.SelectedItem as Product;

            inputProduct.ChangeBinding(mainWindow.ProductsDataGrid.SelectedIndex);
            inputProduct.Title_TextBox.Text = (mainWindow.ProductsDataGrid.SelectedItem as Product).Title;
            inputProduct.Description_TextBox.Text = (mainWindow.ProductsDataGrid.SelectedItem as Product).Description;
            inputProduct.Price_Slider.Text = ((mainWindow.ProductsDataGrid.SelectedItem as Product).Price).ToString();
            if ((mainWindow.ProductsDataGrid.SelectedItem as Product).Type == ProductType.Red)
                inputProduct.Type_ComboBox.SelectedIndex = 0;
            if ((mainWindow.ProductsDataGrid.SelectedItem as Product).Type == ProductType.White)
                inputProduct.Type_ComboBox.SelectedIndex = 1;
            
            string imagePath = selectedProduct.Image;
            if (!string.IsNullOrEmpty(imagePath) && inputProduct.ProductImage.Source == null)
            {
                inputProduct.ProductImage.Source = new BitmapImage(new Uri(imagePath));
            }

            inputProduct.Show();
        }

        public void AddToDataGrid(string title, string description, double price, string uri, ProductType productType, ObservableCollection<Product> Products)
        {
            Products.Add(new Product(title, description, price, uri, productType));
        }

        /*public void ChangeInDataGrid(string title, string description, double price, string uri, ProductType productType, ObservableCollection<Product> Products, int selectIndex)
        {
            string existingImagePath = Products[selectIndex].Image;
            Products[selectIndex].Title = title;
            Products[selectIndex].Description = description;
            Products[selectIndex].Price = price;
            Products[selectIndex].Type = productType;
            mainWindow.ProductsDataGrid.Items.Refresh();
          
           
        }*/

        public bool ValidateInputProduct(string? title, string? description, string? uri, string? price)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            if (string.IsNullOrWhiteSpace(description))
                return false;

           /* if (string.IsNullOrWhiteSpace(uri))
                return false;*/

            if (string.IsNullOrWhiteSpace(price))
                return false;

            if (price.Contains("-") || !double.TryParse(price, out double priceValue))
                return false;

            return true;
        }

        public bool ValidateInputProductAdd(string? title, string? description, string? uri, string? price)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            if (string.IsNullOrWhiteSpace(description))
                return false;

            if (string.IsNullOrWhiteSpace(uri))
                return false;

            if (string.IsNullOrWhiteSpace(price))
                return false;

            if (price.Contains("-") || !double.TryParse(price, out double priceValue))
                return false;

            return true;
        }
        public ProductMemento SaveState()
        {
            var memento = new ProductMemento(mainWindow.Products);
            return memento;
        }

        public void RestoreState(ProductMemento memento)
        {
            mainWindow.Products = memento.Products;
            mainWindow.ProductsDataGrid.ItemsSource = mainWindow.Products;
            mainWindow.ProductsDataGrid.Items.Refresh();
        }
    }
}
