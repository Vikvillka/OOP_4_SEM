using Lab04_OOP.Commands;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab04_OOP.CustomControl
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        private Functions functions;
        public User()
        {
            InitializeComponent();
            functions = new Functions();

        }
        private void RedoState(object sender, ExecutedRoutedEventArgs e)
        {
            if (Functions.mainWindow.caretaker.UndoHistory.Count == 0)
                MessageBox.Show("Stack empty!");
            else
                functions.RestoreState(Functions.mainWindow.caretaker.UndoHistory.Pop());
        }


    }
}
