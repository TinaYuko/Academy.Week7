using Avanade.Allocation.WPF.Messaging.Misc;
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
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();
            //Mi metto in ascolto 

            Messenger.Default.Register<ShowHomeViewMessage>(this, OnShowHomeViewMessageReceived);
        }

        private void OnShowHomeViewMessageReceived(ShowHomeViewMessage message)
        {
           //inizializzo la view Home
           HomeView home= new HomeView();
            //inizializzo la view model
            HomeViewModel vm= new HomeViewModel();

            //le collego
            home.DataContext = vm;

            //visualizzazione della view
            home.Show();

            this.Close();
        }

    }
}
