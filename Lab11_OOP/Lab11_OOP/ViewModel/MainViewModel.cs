using Lab11_OOP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_OOP.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<CourceViewModel> CourceList { get; set; }

        #region Constructor

        public MainViewModel(List<Cource> cource)
        {
            CourceList = new ObservableCollection<CourceViewModel>(cource.Select(b => new CourceViewModel(b)));
        }

        #endregion
    }
}
