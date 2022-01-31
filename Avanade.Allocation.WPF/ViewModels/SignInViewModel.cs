using Avanade.Allocation.Core.BL;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class SignInViewModel: ViewModelBase
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; RaisePropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged();}
        }

        public ICommand SignInCommand { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new RelayCommand( () => ExecuteSignIn(), () => CanExecuteSignIn());
            if (IsInDesignMode)
            {
                Username = "lino.banfi";
                Password = "12345";
            }
            else
            {
                Username = "nennolello";
                Password = "123456";
            }
        }

        private bool CanExecuteSignIn()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        
        }

        private async Task ExecuteSignIn()
        {
            //Inizializzazione business layer
            IUserRepository repo = new UserRepositoryMock();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(repo);

            //Eseguo l'autenticazione tramite il business layer appena creato
            Response response= await layer.SignInAsync(Username, Password);
            if (response.Success)
            {
                //Apro finestra di dialogo con contenuto
                //Messenger.Default.Send(new DialogMessage
                //{
                //    Title = "Login Effettuato",
                //    Content = response.Message
                //});
                //invio del messaggio che apre la finestra home
                Messenger.Default.Send(new ShowHomeViewMessage());
            }
            else
            {
                //finestra con messaggio d'errore
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Error",
                    Content = response.Message
                });
            }
        }
    }
}
