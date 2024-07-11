using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
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

namespace Lab9_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User User = new User();

        public MainWindow()
        {
            InitializeComponent();

            UpdateDatabaseAndGrid();
        }

        private int currentIndex = -1;

        // --------- вперед назад ----------
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                dataGrid.SelectedIndex = currentIndex;
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < dataGrid.Items.Count - 1)
            {
                currentIndex++;
                dataGrid.SelectedIndex = currentIndex;
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
            }
        }

        //=============== Обновление базы данных и DataGrid ===============
        private void UpdateDatabaseAndGrid()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var userComments = db.Users
                        .Include(u => u.Comments)
                        .SelectMany(u => u.Comments, (user, comment) => new UserCommentViewModel
                        {
                            Id = user.Id,
                            Login = user.Login,
                            Password = user.Password,
                            Text = comment.Text,
                            DateTime = comment.DateTime
                        })
                        .ToList();

                    dataGrid.ItemsSource = userComments;
                }
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке
                MessageBox.Show($"Ошибка при обновлении базы данных: {ex.Message}");
            }
        }

        //=============== Добавление в базу данных ===============
        private void AddToDataBase()
        {
            if (ValidateDate())
            {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    string login = loginContainer.Text;
                    string password = passwordContainer.Text;
                    string commentText = new TextRange(Comm_Container.Document.ContentStart, Comm_Container.Document.ContentEnd).Text.Trim();
                    DateTime commentDateTime = DateTime.Now;

                    User existingUser = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                    if (existingUser != null)
                    {
                        Comment comment = new Comment
                        {
                            Text = commentText,
                            DateTime = commentDateTime,
                            UserId = existingUser.Id 
                        };

                        db.Comments.Add(comment);
                    }
                    else
                    {
                        User user = new User
                        {
                            Login = login,
                            Password = password,
                            Comments = new List<Comment>()
                        };

                        Comment comment = new Comment
                        {
                            Text = commentText,
                            DateTime = commentDateTime,
                            UserId = user.Id 
                        };

                        user.Comments.Add(comment);
                        db.Users.Add(user);
                        db.Comments.Add(comment);
                    }

                    db.SaveChanges();
                }

                UpdateDatabaseAndGrid();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            AddToDataBase();
        }

        private void DeleteSelectedItem()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    dynamic selectedUser = dataGrid.SelectedItem;

                    if (selectedUser != null)
                    {
                        int userId = selectedUser.Id;
                        User user = db.Users.Include(u => u.Comments).FirstOrDefault(u => u.Id == userId);

                        if (user != null)
                        {
                            db.Users.Remove(user);
                        }

                        db.SaveChanges();
                    }
                }

                UpdateDatabaseAndGrid();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка при удалении из базы данных: {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItem();
           
        }

        //----------------- Редактирование -----------------
        private void FillTextBoxesFromSelectedRow()
        {

            if (dataGrid.SelectedItem != null)
            {
                var selectedUser = (UserCommentViewModel)dataGrid.SelectedItem;

                loginContainer.Text = selectedUser.Login;
                passwordContainer.Text = selectedUser.Password;
                Comm_Container.Document.Blocks.Clear();
                Comm_Container.Document.Blocks.Add(new Paragraph(new Run(selectedUser.Text)));
            }
        }

        //=================== Изменение в базе данных ===================
        private void UpdateDatabaseFromTextBoxes()
        {
            
            if (dataGrid.SelectedItem != null)
            {
                if (ValidateDate())
                {
                    var selectedUser = (UserCommentViewModel)dataGrid.SelectedItem;
                    int userId = selectedUser.Id;
                    DateTime date = selectedUser.DateTime;

                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.UpdateUserAndComment(userId, loginContainer.Text, passwordContainer.Text, new TextRange(Comm_Container.Document.ContentStart, Comm_Container.Document.ContentEnd).Text.Trim(), date);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }   
            }
            UpdateDatabaseAndGrid();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            FillTextBoxesFromSelectedRow();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatabaseFromTextBoxes();

            loginContainer.Clear();
            passwordContainer.Clear();
            Comm_Container.Document.Blocks.Clear();
        }

        //===================== Поиск по логину =====================
        private async Task<List<User>> SearchUsersAsync(string searchText)
        {
            using (AppDbContext c = new AppDbContext())
            {
                try
                {
                    var logins = await c.Users.FromSql(FormattableStringFactory.Create($"SELECT * FROM Users where Login like '%{searchText}%'"))
                        .ToListAsync();
                    return logins;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw; 
                }
            }
        }
        private async void Login_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var logins = await SearchUsersAsync(LoginSearch.Text);
                dataGrid.ItemsSource = logins;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               
            }
        }
        
        //===================== Поиск по дате =====================
        private async Task<List<Comment>> SearchCommentsByDateAsync(DateTime startDate, DateTime endDate)
        {
            using (AppDbContext c = new AppDbContext())
            {
                try
                {
                    var comm = await c.Comments.Where(comment => comment.DateTime >= startDate && comment.DateTime < endDate)
                        .ToListAsync();
                    return comm;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw; 
                }
            }
        }
        private async void Date_Search_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext c = new AppDbContext())
            {
                using (var tran = await c.Database.BeginTransactionAsync())
                {
                    try
                    {
                        DateTime? selectedDate = datePicker.SelectedDate;
                        if (selectedDate.HasValue)
                        {
                            DateTime startDate = selectedDate.Value.Date;

                            DateTime dateToCompare = new DateTime(2011, 3, 22);
                            if (startDate < dateToCompare)
                            {
                                throw new Exception("Дата не может быть меньше 2012");
                            }

                            DateTime endDate = startDate.AddDays(1);

                            var comm = await SearchCommentsByDateAsync(startDate, endDate);
                            
                            if (comm != null)
                                dataGrid.ItemsSource = comm;
                        }
                        await tran.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await tran.RollbackAsync();
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        //============================ Поис по логину и дате ===========================
        private async Task<List<UserCommentViewModel>> SearchCommentsByBoth(DateTime startDate, DateTime endDate)
        {
            using (AppDbContext c = new AppDbContext())
            {
                try
                {
                    var strLogin = LoginSearch.Text;
                    var result = await c.Users
                        .Include(u => u.Comments)
                        .SelectMany(u => u.Comments.Select(c => new UserCommentViewModel
                        {
                            Id = u.Id,
                            Login = u.Login,
                            Password = u.Password,
                            Text = c.Text,
                            DateTime = c.DateTime
                        }))
                        .Where(comment => comment.DateTime >= startDate && comment.DateTime < endDate && comment.Login.Contains(strLogin))
                        .ToListAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
        private async void searchBoth_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext c = new AppDbContext())
            {
                using (var tran = await c.Database.BeginTransactionAsync())
                {
                    try
                    {
                        DateTime? selectedDate = datePicker.SelectedDate;
                        if (selectedDate.HasValue)
                        {
                            DateTime startDate = selectedDate.Value.Date;

                            DateTime dateToCompare = new DateTime(2011, 3, 22);
                            if (startDate < dateToCompare)
                            {
                                throw new Exception("Дата не может быть меньше 2012");
                            }

                            DateTime endDate = startDate.AddDays(1);

                            var comm = await SearchCommentsByBoth(startDate, endDate);

                            if (comm != null)
                                dataGrid.ItemsSource = comm;
                        }
                        await tran.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await tran.RollbackAsync();
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
           UpdateDatabaseAndGrid();
         
        }
        public bool ValidateDate()
        {
            if (this.loginContainer.Text.IsNullOrEmpty())
            {
                return false;
            }
            else if (this.passwordContainer.Text.IsNullOrEmpty())
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(new TextRange(Comm_Container.Document.ContentStart, Comm_Container.Document.ContentEnd).Text))
            {
                return false;
            }

            return true;
        }
    }

    public class UserCommentViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}