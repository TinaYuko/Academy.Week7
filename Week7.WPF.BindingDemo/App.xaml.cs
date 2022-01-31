using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.WPF.BindingDemo.Entities;
using Week7.WPF.BindingDemo.ViewModel;

namespace Week7.WPF.BindingDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Collegamento tra Interfaccia e Mock
            IRepoPerson repoPerson = new RepoPersonMock();
            //View Model da utilizzare nell'app
            MainWindowViewModel vm = new MainWindowViewModel(repoPerson);
            //Prima finestra da lanciare, allo startup
            MainWindow window = new MainWindow(vm);
            window.Show();
        }
    }
}
