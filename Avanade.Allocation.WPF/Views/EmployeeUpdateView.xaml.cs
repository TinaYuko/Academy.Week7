using Avanade.Allocation.WPF.Messaging.Employee;
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
    /// Interaction logic for EmployeeUpdateView.xaml
    /// </summary>
    public partial class EmployeeUpdateView : Window
    {
        public EmployeeUpdateView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseUpdateEmployeeMessage>(this, _ => Close());

            //Alla chiusura della finestra
            Closing += (s, e) =>
            {
                //Eseguo la de-registrazione di tutti i messaggi a cui mi sono
                //registrati all'interno dei questa view e del suo viewmodel
                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }
    }
}
