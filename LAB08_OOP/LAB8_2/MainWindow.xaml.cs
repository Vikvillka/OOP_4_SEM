using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.RegularExpressions;

namespace LAB8_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectStr;
        SqlConnection connect;
        SqlDataAdapter adapter;
        DataTable datTable;

        Account acc = new Account();  

        public MainWindow()
        {
            InitializeComponent();

            connectStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            if (CheckDatabaseExists())
            {
                connect = new SqlConnection(connectStr);
            }
            else
            {
                CreateDatabase();
                connect = new SqlConnection(connectStr);
            }

            phonesGrid.RowEditEnding += PhonesGrid_RowEditEnding;

            Type_Box.SelectedItem = Type_Box.Items[1];
        }


        private bool CheckDatabaseExists()
        {
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        //------------ Создание базы данных, если она не существует-----------
        private void CreateDatabase()
        {
            string databaseName = "lab8oop";
            bool databaseExists = CheckDatabaseExists(databaseName);

            if (!databaseExists)
            {
                SqlConnectionStringBuilder masterConnectionStringBuilder = new SqlConnectionStringBuilder(connectStr);
                masterConnectionStringBuilder.InitialCatalog = "master";

                using (SqlConnection masterConnection = new SqlConnection(masterConnectionStringBuilder.ConnectionString))
                {
                    masterConnection.Open();

                    string createDatabaseScript = $"CREATE DATABASE {databaseName}";
                    SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseScript, masterConnection);
                    createDatabaseCommand.ExecuteNonQuery();
                }
            }

            SqlConnectionStringBuilder databaseConnectionStringBuilder = new SqlConnectionStringBuilder(connectStr);
            databaseConnectionStringBuilder.InitialCatalog = databaseName;
            connectStr = databaseConnectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                string createOwnersTableScript =
                    @"CREATE TABLE [dbo].[Owners] (
                [id] INT IDENTITY (1, 1) NOT NULL,
                [fio] NVARCHAR (50) NOT NULL,
                [birthDate] DATETIME NOT NULL,
                [passport] NCHAR (15) NOT NULL,
                [ImageData] NVARCHAR(255) NULL,
                CONSTRAINT [PK__Owners__3214EC071237FB30] PRIMARY KEY CLUSTERED ([Id] ASC)
            )";
                SqlCommand createOwnersTableCommand = new SqlCommand(createOwnersTableScript, connection);
                createOwnersTableCommand.ExecuteNonQuery();

                string createAccountTableScript = @"CREATE TABLE [dbo].[Account] (
            [id] INT IDENTITY (11000, 1) NOT NULL,
            [ownerId] INT NOT NULL,
            [fio] NVARCHAR (50) NOT NULL,
            [accountType] NVARCHAR (50) NOT NULL,
            [sendDate] DATETIME NULL,
            [startBalance] INT NULL,
            [wallet] NVARCHAR (10) NULL,
            CONSTRAINT [PK__Account__3214EC071237FB30] PRIMARY KEY CLUSTERED ([Id] ASC),
            CONSTRAINT [FK__Account__OwnerId__267ABA7A] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owners] ([Id])
        )";
                SqlCommand createAccountTableCommand = new SqlCommand(createAccountTableScript, connection);
                createAccountTableCommand.ExecuteNonQuery();
            }
        }

        private bool CheckDatabaseExists(string databaseName)
        {
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                string checkDatabaseScript = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";
                SqlCommand checkDatabaseCommand = new SqlCommand(checkDatabaseScript, connection);
                int databaseCount = (int)checkDatabaseCommand.ExecuteScalar();

                return databaseCount > 0;
            }
        }


        private void PhonesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateOfG.Text = $"Дата открытия счета: {DateTime.Now.ToShortDateString()}";
            Load();
           
        }
        //====================== ЗАГРУЗКА ДАННЫХ ИЗ БД ========================
        public void Load()
        {
           string sql = "SELECT * FROM Account JOIN Owners ON Account.ownerId = Owners.id;";

            datTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectStr);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(datTable);
                phonesGrid.ItemsSource = datTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // ============================== обновление данных в базе данных =======================
        private void UpdateDB()
        {
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Account JOIN Owners ON Account.ownerId = Owners.id", connection))
                        {
                            adapter.RowUpdating += Adapter_RowUpdating;

                            SqlCommand updateCommand = new SqlCommand(
                                "UPDATE Account " +
                                "SET AccountType = @AccountType, sendDate = @sendDate, startBalance = @startBalance, wallet = @wallet " +
                                "FROM Account JOIN Owners ON Account.ownerId = Owners.id " +
                                "WHERE Account.fio = @FIO; " +
                                "UPDATE Owners " +
                                "SET birthDate = @birthDate, passport = @passport " +
                                "WHERE fio = @fio", connection, transaction);

                            updateCommand.Parameters.Add("@AccountType", SqlDbType.NVarChar, 50, "AccountType");
                            updateCommand.Parameters.Add("@sendDate", SqlDbType.DateTime, 0, "sendDate");
                            updateCommand.Parameters.Add("@startBalance", SqlDbType.Int, 0, "startBalance");
                            updateCommand.Parameters.Add("@wallet", SqlDbType.NVarChar, 10, "wallet");
                            updateCommand.Parameters.Add("@fio", SqlDbType.NVarChar, 50, "fio");
                            updateCommand.Parameters.Add("@birthDate", SqlDbType.DateTime, 0, "birthDate");
                            updateCommand.Parameters.Add("@passport", SqlDbType.NChar, 15, "passport");

                            adapter.UpdateCommand = updateCommand;

                            adapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
                            adapter.Update(datTable);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.StatementType == StatementType.Update)
            {
                int startBalance = Convert.ToInt32(e.Row["startBalance"]);

                if (startBalance < 0) 
                {
                    e.Status = UpdateStatus.SkipCurrentRow;
                    throw new Exception("Стартовый баланс не может быть меньше нуля.");
                }
            }
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
            Load();
            //MessageBox.Show("Данные обновлены");
        }

        //===================================== удаление =========================================
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)phonesGrid.SelectedItem;

                int id = Convert.ToInt32(selectedRow["id"]);

                DeleteFromDB(new List<int> { id });
 
            }
            Load();
        }

        //--------- удаление данных из базы данных ----------
        private void DeleteFromDB(List<int> recordIds)
        {
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (int recordId in recordIds)
                        {
                            DataRowView selectedRow = (DataRowView)phonesGrid.SelectedItem;
                            int walletValue = Convert.ToInt32(selectedRow["id"]); 
                            if (walletValue > 1000 )
                            {
                                SqlCommand deleteCommand = new SqlCommand(
                                    "DELETE FROM Account WHERE id = @id", connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@id", recordId);
                                deleteCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                SqlCommand deleteCommand = new SqlCommand(
                                    "DELETE FROM Owners WHERE id = @id", connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@id", recordId);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при удалении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }

        // =============================== создание нового счета =====================================
        private void Create_Click(object sender, RoutedEventArgs e)
        {          
            this.acc.Owner.FIO = FIO_Container.Text;
            this.acc.Owner.Passport = Pasport_Container.Text;
            int sliderVal = Convert.ToInt32(StartB_Slider.Value);
            this.acc.Balance = sliderVal;
           
            if (Type_Box.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)Type_Box.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                this.acc.AccountType = selectedValue;
            }

            try
            {
                if (ValidateValue())
                {
                    using (SqlConnection connection = new SqlConnection(connectStr))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            SqlCommand c = new SqlCommand();
                            c.Connection = connection;
                            c.Transaction = transaction;

                            c.CommandText = "INSERT Owners values (@fio, @birthDate, @passport, @ImageData);";
                            c.Parameters.AddWithValue("@fio", this.acc.Owner.FIO);
                            c.Parameters.AddWithValue("@birthDate", this.acc.Owner.BirthDate);
                            c.Parameters.AddWithValue("@passport", this.acc.Owner.Passport);
                            c.Parameters.AddWithValue("@imageData", imageUri);
                            c.ExecuteNonQuery();

                            c.CommandText = "SELECT TOP 1 id\r\nFROM Owners\r\nORDER BY id DESC;";
                            int ownerId = Convert.ToInt32(c.ExecuteScalar());

                            c.CommandText = "INSERT INTO Account (ownerId, FIO, accountType, sendDate, startBalance, wallet) VALUES ( @ownerId, @FIOO, @accountType, @sendDate, @startBalance, @wallet);";
                            c.Parameters.AddWithValue("@ownerId", ownerId);
                            c.Parameters.AddWithValue("@FIOO", this.acc.Owner.FIO);
                            c.Parameters.AddWithValue("@accountType", this.acc.AccountType);
                            c.Parameters.AddWithValue("@sendDate", this.acc.OpenDate);
                            c.Parameters.AddWithValue("@startBalance", this.acc.Balance);
                            c.Parameters.AddWithValue("@wallet", this.acc.Wallet);
                            c.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Cчет создан!", "Поздравляем", MessageBoxButton.OK, MessageBoxImage.Information);
                            acc = new Account();

                            FIO_Container.Clear();
                            Pasport_Container.Clear();
                            BirthD_Picker.SelectedDate = null;
                            ProductImage.Source = null;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка при создании счета: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                } else
                {
                    MessageBox.Show("Не удалось добавить данные, проверьте правильность вводимых данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                string errormsg = "";
                foreach (SqlError err in ex.Errors)
                {
                    errormsg += err.Message + ",";
                }
                MessageBox.Show(errormsg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        ///--------- выбор типа счета ----------
        private void Type_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            this.acc.AccountType = comboBox.Text;
        }

        //--------- выбор валюты ----------
        private void RUB_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.IsChecked == true)
            {
                switch (radioButton.Name)
                {
                    case "RUB":
                        this.acc.Wallet = "RUB";
                        break;
                    case "BYN":
                        this.acc.Wallet = "BYN";
                        break;
                    case "USD":
                        this.acc.Wallet = "USD";
                        break;
                }
            }
        }
      
        //--------- выбор даты ----------
        private void BirthD_Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = BirthD_Picker.SelectedDate;
            if (selectedDate != null)
            {
                this.acc.Owner.BirthDate = selectedDate.Value;
                this.acc.OpenDate = DateTime.Today;
            }
        }
        
        //-------------- стартовый баланс --------------
        private void StartB_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            int sliderVal = Convert.ToInt32(StartB_Slider.Value);
            this.valueSlider.Text = sliderVal.ToString();                        
            this.acc.Balance = sliderVal;
        }

        private int currentIndex = -1;

        // --------- вперед назад ----------
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                phonesGrid.SelectedIndex = currentIndex;
                phonesGrid.ScrollIntoView(phonesGrid.SelectedItem);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < phonesGrid.Items.Count - 1)
            {
                currentIndex++;
                phonesGrid.SelectedIndex = currentIndex;
                phonesGrid.ScrollIntoView(phonesGrid.SelectedItem);
            }
        }

        // ----------- поиск ----------
        private DataTable GetDataFromDatabase(string _query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectStr))
                {
                    SqlCommand command = new SqlCommand(_query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    connection.Open();
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных из базы данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dataTable;
        }


        //=============================== ЗАПРОСЫ К БД =================================
        private void Wallet_Search_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = GetDataFromDatabase($"exec Find_type @wallet = \'{Wallet_Search_tb.Text}\'");
            phonesGrid.ItemsSource = dataTable.DefaultView;
        }

        private void FIO_Search_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = GetDataFromDatabase($"exec Find_Surname @srnm = \'{FIO_SEARCH_TB.Text}\'");
            phonesGrid.ItemsSource = dataTable.DefaultView;
        }

        private void printOwners_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = GetDataFromDatabase($"SELECT DISTINCT * FROM Owners");
            phonesGrid.ItemsSource = dataTable.DefaultView;
        }

        private void printAcc_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        //=============================================================================

        //----------------- валидация -----------------
        private bool ValidateValue()
        {
            string fio = FIO_Container.Text;
            string date = BirthD_Picker.Text;
            string passport = Pasport_Container.Text;


            if (!ValidateFIO(fio))
            {
                if (fio.Length > 40)
                {
                    return false;
                }
                MessageBox.Show("Недопустимое значение ФИО (Введите полное ФИО)");
                return false;
            }

            if (!validateDate())
            {
                MessageBox.Show("Недопустимое значение даты");
                return false;
            }
            if (!validatePassport(passport))
            {
                MessageBox.Show("Недопустимое значение пасспорта (Верный вариант: HP7434236");
                return false;
            }
            
            if (string.IsNullOrEmpty(imageUri))
            {
                MessageBox.Show("Нет изображения");
                return false;
            }


            return true;
        }
        
        private bool validatePassport(string passport)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{2}\d{7}$");
            if (!regex.IsMatch(passport))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(passport))
            {
                return false;
            }
            return true;
        }   

        private bool ValidateFIO(string fio)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]+\s[a-zA-Zа-яА-Я]+\s[a-zA-Zа-яА-Я]+$");
            if (!regex.IsMatch(fio))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fio))
            {
                return false;
            }
            return true;
        }

        public bool validateDate()
        {
            DateTime? selectedDate = BirthD_Picker.SelectedDate;
            if (selectedDate != null)
            {
                if (selectedDate.Value > DateTime.Now)
                {
                    MessageBox.Show("Дата рождения не может быть больше текущей даты");
                    return false;
                }
                return true;
            }

            return false;
        }

        private string imageUri;


        //----------------- добавить изображение -----------------
        private void addImg_Click(object sender, RoutedEventArgs e)
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

        // --------- закрытие приложения ----------
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connect.Close();
        }

        private void updateErrorButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}