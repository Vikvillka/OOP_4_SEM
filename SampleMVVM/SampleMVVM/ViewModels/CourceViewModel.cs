using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;

namespace SampleMVVM.ViewModels
{
    class CourceViewModel : ViewModelBase
    {
        public Cource Cource;

        public CourceViewModel(Cource cource)
        {
            this.Cource = cource;
        }

        public string Name
        {
            get { return this.Cource.Name; }
            set
            {
                Cource.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public int CountHour
        {
            get { return this.Cource.CountHour; }
            set
            {
                Cource.CountHour = value;
                OnPropertyChanged("CountHour");
            }
        }
        public string NameTeacher
        {
            get { return this.Cource.NameTeacher; }
            set
            {
                Cource.NameTeacher = value;
                OnPropertyChanged("NameTeacher");
            }
        }
        public int CountStudent
        {
            get { return this.Cource.CountStudent; }
            set
            {
                Cource.CountStudent = value;
                OnPropertyChanged("CountStudent");
            }
        }

        #region Commands

        #region ОтменаЗапись

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(removeItem, CanRemoveItem);
                }
                return getItemCommand;
            }
        }
        private bool CanRemoveItem()
        {
            return CountStudent < 30;
        } 

        private void removeItem()
        {
            CountStudent++;
        }

        #endregion

        #region Запись

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(AddItem, CanAddItem);
                }
                return giveItemCommand;
            }
        }

        private void AddItem()
        {
            CountStudent--;
        }

        private bool CanAddItem()
        {
            return CountStudent > 0;
        }

        #endregion

        #endregion
    }
}
