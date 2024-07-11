using Lab04_OOP.Commands;
using Lab04_OOP.Memento;
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
        private void UndoState(object sender, ExecutedRoutedEventArgs e)
        {
            if (Functions.mainWindow.caretaker.UndoHistory.Count == 0)
                MessageBox.Show("Стек пуст!");
            else
            {
                Functions.mainWindow.caretaker.RedoHistory.Push(functions.SaveState());
                functions.RestoreState(Functions.mainWindow.caretaker.UndoHistory.Pop());
            }
        }
        public void RedoState(object sender, ExecutedRoutedEventArgs e)
        {
            if (Functions.mainWindow.caretaker.RedoHistory.Count == 0)
            {
                MessageBox.Show("Нет действий для повтора!");
                return;
            }

            var memento = Functions.mainWindow.caretaker.RedoHistory.Pop();
            Functions.mainWindow.caretaker.UndoHistory.Push(new ProductMemento(Functions.mainWindow.Products));
            functions.RestoreState(memento);
        }

    }
}
