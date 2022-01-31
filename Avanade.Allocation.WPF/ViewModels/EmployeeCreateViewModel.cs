using Avanade.Allocation.Core.BL;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
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
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeCreateViewModel: ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; RaisePropertyChanged(); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; RaisePropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; RaisePropertyChanged(); }
        }
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; RaisePropertyChanged(); }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; RaisePropertyChanged(); }
        }

        public EmployeeCreateViewModel()
        {
            CreateCommand = new RelayCommand(() => ExecuteCreate(),
                                             () => CanExecuteCreate());
            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                  {
                      (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                  };
            }
        }

        private bool CanExecuteCreate()
        {
            //Il pulsante create è abilitato solo se tutti i campi sono valorizzati
            return !string.IsNullOrEmpty(FirstName) && 
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(Salary.ToString()) &&
                !string.IsNullOrEmpty(DateOfBirth.ToString());
        }

        private void ExecuteCreate()
        {
            //Recupero i dati dalle proprietà del view model e creo una nuova entità
            var entity= new Employee
            {
                FirstName=FirstName,
                LastName=LastName,
                Email=Email,
                Salary=Salary,
                DateOfBirth=DateOfBirth,
                IsEnabled=true
            };

            //inizializzo il bl
            var layer = new MainBusinessLayer(new EmployeeRepositoryMock());
            //richiamo l'operazione del layer
            var response= layer.CreateEmployee(entity);
            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title ="Something wrong",
                    Content = response.Message,
                    Icon =System.Windows.MessageBoxImage.Warning
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title="Creazione completata",
                    Content=response.Message,
                    Icon=System.Windows.MessageBoxImage.Information
                });
            }
            Messenger.Default.Send(new CloseCreateEmployeeMessage());
        }
    }
}
