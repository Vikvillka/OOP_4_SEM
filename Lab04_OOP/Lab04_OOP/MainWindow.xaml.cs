using Lab04_OOP.Commands;
using Lab04_OOP.Memento;
using Lab04_OOP.Models;
using Lab04_OOP.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace Lab04_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected internal ObservableCollection<Product> Products = new ObservableCollection<Product>();
        private Functions functions;
        protected internal Caretaker caretaker;

        private readonly string logFilePath = "D:\\4_SEM_LABS\\OOP\\Lab04_OOP\\log.txt";
        public MainWindow()
        {
            InitializeComponent();

            functions = new Functions(this);
            caretaker = new Caretaker();
           
            StateChanged += MainWindow_StateChanged;

            Cursor customCursor = new Cursor("D:\\4_SEM_LABS\\OOP\\Lab04_OOP\\Lab04_OOP\\Img\\Arrow.cur");
            this.Cursor = customCursor;

            List<string> styles = new List<string> { "RadTheme", "GreenTheme" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "RadTheme";

            if (File.Exists(logFilePath))
            {
                ClearLogFile();
            }
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            string gridStyleKey = style + "Grid";
            string buttonStyleKey = style + "But";

            stylePanel.Style = (Style)Application.Current.FindResource(style);
            styleGrid.Style = (Style)Application.Current.FindResource(gridStyleKey);
            Form_Button.Style = (Style)Application.Current.FindResource(buttonStyleKey);
            Add_Button.Style = (Style)Application.Current.FindResource(buttonStyleKey);
            Filter_Button.Style = (Style)Application.Current.FindResource(buttonStyleKey);
            
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void ProductsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = "ProductsData.json";
            List<Product> lstPr;

            if (File.Exists(jsonFilePath))
            {
                using (FileStream file = new FileStream(jsonFilePath, FileMode.Open))
                {
                    lstPr = JsonSerializer.Deserialize<List<Product>>(file);
                }
            }
            else
            {
                lstPr = new List<Product>();
            }

            foreach (Product pr in lstPr)
            {
                Products.Add(pr);
            }

            ProductsDataGrid.ItemsSource = Products;

            LoadLanguageDictionary("ru");
        }
        private void RemoveDataGridItem(object sender, ExecutedRoutedEventArgs e)
        {
            caretaker.UndoHistory.Push(functions.SaveState());
            functions.RemoveDataGridItem(Products);
            LogAction("Удаление продукта");
        }
        private void AddProductInputForm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            caretaker.UndoHistory.Push(functions.SaveState());
            functions.OpenProductForm(Products, functions);
            LogAction("Добавление продукта");
        }
        private void ChangeDataGridItem(object sender, ExecutedRoutedEventArgs e)
        {
            caretaker.UndoHistory.Push(functions.SaveState());
            functions.ChangeProductForm(Products, functions);
            LogAction("Изменение продукта");
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Product> lstPr = new List<Product>();
            foreach (Product pr in Products)
                lstPr.Add(pr);
            using (FileStream file = new FileStream("ProductsData.json", FileMode.Create))
            {
                JsonSerializer.Serialize<List<Product>>(file, lstPr);
            }
            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                ProductsDataGrid.ItemsSource = Products;
            }
            else
            {
                string searchText = SearchBox.Text;
                var regex = new Regex(searchText, RegexOptions.IgnoreCase);

                var searchedProducts = Products.Where(p => regex.IsMatch(p.Title) || regex.IsMatch(p.Price.ToString())).ToList();

                ProductsDataGrid.ItemsSource = new ObservableCollection<Product>(searchedProducts);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            double minPrice, maxPrice;
            bool isMinValid = double.TryParse(Min.Text, out minPrice);
            bool isMaxValid = double.TryParse(Max.Text, out maxPrice);

            if (isMinValid && isMaxValid)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(ProductsDataGrid.ItemsSource);
                view.Filter = (item) =>
                {
                    Product product = item as Product;
                    return product.Price >= minPrice && product.Price <= maxPrice;
                };
            }
            else
            {
              
                ICollectionView view = CollectionViewSource.GetDefaultView(ProductsDataGrid.ItemsSource);
                view.Filter = null;
            }
        }

        private void ChangeLanguageButton_Click(object sender, RoutedEventArgs e)
        { 
            string language = ((Button)sender).Tag.ToString();

            LoadLanguageDictionary(language);
        }

        private void LoadLanguageDictionary(string culture)
        {
            string dictPath = $"resources.{culture}.xaml";
            Uri dictUri = new Uri(dictPath, UriKind.Relative);

            ResourceDictionary langDict = Application.LoadComponent(dictUri) as ResourceDictionary;

            ResourceDictionary oldLangDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(dictionary => dictionary.Source != null && dictionary.Source.OriginalString == dictPath);

            Application.Current.Resources.MergedDictionaries.Add(langDict);

        }

        private void LogAction(string action)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {

                    writer.WriteLine($"Действие: {action}, Время: {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ошибка записи в лог-файл: {ex.Message}");
            }
        }

        private void ClearLogFile()
        {
            try
            {

                File.WriteAllText(logFilePath, string.Empty);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ошибка очистки лог-файла: {ex.Message}");
            }
        }

    }

}

