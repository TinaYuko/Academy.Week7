using Avanade.Allocation.WPF.Messaging.Employee;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public ICommand ExitCommand { get; set; }
        public ICommand ShowEmployeesCommand { get; set; }

        public HomeViewModel()
        {
            //Inizializzo i command
            ShowEmployeesCommand= new RelayCommand (()=>ExecuteShowEmployee());
            ExitCommand= new RelayCommand (()=>ExecuteExit());
        }

        private void ExecuteExit()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Conferma uscita",
                Content ="Are u sure?",
                Icon= MessageBoxImage.Question,
                Buttons= MessageBoxButton.YesNo,
                Callback = (result) =>
                {
                    //Esco dall'app solo se l'utente preme yes
                    if (result==MessageBoxResult.Yes)
                    {
                        Messenger.Default.Send( new ShutDownApplicationMessage());
                    }
                }
            });
        }

        private void ExecuteShowEmployee()
        {
            Messenger.Default.Send(new ShowEmployeeMessage());
        }
    }
}
