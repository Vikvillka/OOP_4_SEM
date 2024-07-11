using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ObservableCollection<Cource> Cources { get; set; }
        AppDbContext db = new AppDbContext();

        public App()
        {
            db = new AppDbContext();
            db.Database.EnsureCreated();
            Cources = new ObservableCollection<Cource>(db.Cources);
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {

            MainView view = new MainView();
            MainViewModel viewModel = new MainViewModel(Cources);
           /* view.DataContext = viewModel;
            view.Show();*/
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            db.SaveChanges();
        }
    }
}
