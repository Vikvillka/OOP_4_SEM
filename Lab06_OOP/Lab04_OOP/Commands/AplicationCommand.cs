using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab04_OOP.Commands
{
    public class AplicationCommand
    {
        private static RoutedUICommand addCommand =
            new RoutedUICommand("Add", "Add", typeof(AplicationCommand));
        public static RoutedUICommand AddCommand
        {
            get { return addCommand; }
        }

        private static RoutedUICommand removeCommand =
            new RoutedUICommand("remove", "remove", typeof(AplicationCommand));
        public static RoutedUICommand RemoveCommand
        {
            get { return removeCommand; }
        }
        private static RoutedUICommand changeCommand =
            new RoutedUICommand("addProductToData", "addProductToData", typeof(AplicationCommand));
        public static RoutedUICommand ChangeCommand
        {
            get { return changeCommand; }
        }
        //--------------------------------------------
        private static RoutedUICommand addProductToDataGridCommand =
            new RoutedUICommand("addProductToData", "addProductToData", typeof(AplicationCommand));
        public static RoutedUICommand AddProductToDataGrid
        {
            get { return addProductToDataGridCommand; }
        }
        private static RoutedUICommand changeProductInDataGridCommand =
            new RoutedUICommand("addProductToData", "addProductToData", typeof(AplicationCommand));
        public static RoutedUICommand ChangeProductInDataGridCommand
        {
            get { return changeProductInDataGridCommand; }
        }       

        private static RoutedUICommand _closeCommand =
            new RoutedUICommand("Close", "CloseCommand", typeof(AplicationCommand));
        public static RoutedUICommand CloseCommand
        {
            get
            {
                return _closeCommand;
            }
        }

        private static RoutedUICommand _switchLang =
            _switchLang = new RoutedUICommand("Lang", "SwitchLangCommand", typeof(AplicationCommand));
        public static RoutedUICommand SwitchLangCommand
        {
            get
            {
                return _switchLang;
            }
        }

        private static RoutedUICommand saveStateCommand =
           new RoutedUICommand("saveStateCommant", "saveStateCommant", typeof(AplicationCommand));
        public static RoutedUICommand SaveStateCommand
        {
            get { return saveStateCommand; }
        }
        private static RoutedUICommand restoreStateCommand =
            new RoutedUICommand("restoreStateCommand", "restoreStateCommand", typeof(AplicationCommand));
        public static RoutedUICommand RestoreStateCommand
        {
            get { return restoreStateCommand; }
        }


    }
}
