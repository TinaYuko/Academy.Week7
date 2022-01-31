using Esercitazione_2.Core;
using Esercitazione_2.Core.BL;
using Esercitazione_2.Core.Mock.Repo;
using Esercitazione_2.Core.Repo;
using Esercitazione_2.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Esercitazione_2.WPF.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }

        public ICommand SignInCommand { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new RelayCommand(
                () => ExecuteSignIn(),
                () => CanExecuteSignIn());
            if (IsInDesignMode)
            {
                UserName = "giuseppe.verdi";
                Password = "abcdeghi";
            }
            else
            {
                UserName = "mario.rossi";
                Password = "123456";
            }

        }

        private bool CanExecuteSignIn()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        private async Task ExecuteSignIn()
        {
            //Inizializzazione business layer
            IUserRepository repo = new UserRepositoryMock();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(repo);

            //Eseguo l'autenticazione mediante il business layer appena creato
            Response response = await layer.SignInAsync(UserName, Password);
            if (response.Success)
            {
                //APRI FINESTRA DI DIALOGO CON CONTENUTO
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Log-in Effettuato",
                    Content = response.Message
                });
            }
            else
            {
                //Finestra di dialogo con il messaggio
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Error",
                    Content = response.Message
                });
            }
        }
    }
}
