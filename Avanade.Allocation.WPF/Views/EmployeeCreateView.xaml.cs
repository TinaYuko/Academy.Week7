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
    /// Interaction logic for EmployeeCreateView.xaml
    /// </summary>
    public partial class EmployeeCreateView : Window
    {
        public EmployeeCreateView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseCreateEmployeeMessage>(this, _=> Close());

            Closing += (s, e) =>
             {
                 //mi de registro da tutti i messaggi a cui mi son registrato

                 Messenger.Default.Unregister(this);
                 Messenger.Default.Unregister(DataContext);
             };
        }


    }
}
