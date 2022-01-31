using Avanade.Allocation.WPF.Messaging.Employee;
using Avanade.Allocation.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;

namespace Avanade.Allocation.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowEmployeeMessage>(this, OnShowEmployeeMessageReceived);
        }

        private void OnShowEmployeeMessageReceived(ShowEmployeeMessage obj)
        {
            EmployeeEditorView view= new EmployeeEditorView();
            EmployeeEditorViewModel vm = new EmployeeEditorViewModel();
            view.DataContext = vm;
            view.Show();

        }
    }
}
