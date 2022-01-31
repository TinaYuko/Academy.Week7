using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.WPF.Messaging.Misc;
using Avanade.Allocation.WPF.ViewModels;
using Avanade.Allocation.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Avanade.Allocation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Mi metto in ascolto di eventuali messaggi
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);
            Messenger.Default.Register<ShutDownApplicationMessage>(this, _ => Current.Shutdown());
            //inizializziamo database
            AllocationMockStorage.Initialize();

            //inizializzo la view di login
            SignInView view = new SignInView();

            //Inizializzo il view model associato alla login
            SignInViewModel vm = new SignInViewModel();

            //faccio il collegamento tra view e view model
            view.DataContext = vm;

            //richiamo la visualizzazione della view
            view.Show();
            base.OnStartup(e);

        }

        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(message.Content, message.Title, message.Buttons, message.Icon);
            
            if (message.Callback != null)
            {
                message.Callback(result);
            }
        }
    }
}
