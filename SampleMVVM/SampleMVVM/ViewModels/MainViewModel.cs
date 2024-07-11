using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using SampleMVVM.Commands;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<CourceViewModel> CourceList { get; set; } 

        #region Constructor

        public MainViewModel(ObservableCollection<Cource> cource)
        {
            CourceList = new ObservableCollection<CourceViewModel>(cource.Select(b => new CourceViewModel(b)));
        }

        #endregion
    }
}
