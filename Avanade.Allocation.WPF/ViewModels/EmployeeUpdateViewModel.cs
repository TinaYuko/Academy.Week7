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
    public class EmployeeUpdateViewModel: ViewModelBase
    {
        private Employee entity;
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }
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

        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; RaisePropertyChanged(); }
        }
        public EmployeeUpdateViewModel()
        {
            UpdateCommand = new RelayCommand(() => ExecuteUpdate(), ()=>CanExecuteUpdate());
            CancelCommand = new RelayCommand(() => ExecuteCancel());

            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (UpdateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }
        public EmployeeUpdateViewModel(Employee entity) : this()
        {
            //Validazione argomento
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Inizializzazione delle props
            this.entity = entity;
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Salary = entity.Salary;
            Email = entity.Email;
            IsEnabled = entity.IsEnabled;
        }

        private bool CanExecuteUpdate()
        {
            //Il pulsante create è abilitato solo se tutti i campi sono valorizzati
            return !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Email);
        }

        private void ExecuteCancel()
        {
            //Lancia un evento di chiusura della finestra di update
            Messenger.Default.Send(new CloseUpdateEmployeeMessage());
        }
        private void ExecuteUpdate()
        {
            //Recupero i dati dalle proprietà del view model e creo una nuova entità
            var entity = new Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Salary = Salary,
                DateOfBirth = DateOfBirth,
                IsEnabled = true
            };

            //inizializzo il bl
            var layer = new MainBusinessLayer(new EmployeeRepositoryMock());
            //richiamo l'operazione del layer
            var response = layer.UpdateEmployee(entity);
            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Something wrong",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Aggiornamento completato",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Information
                });
            }
            // TODO Messenger.Default.Send(new CloseUpdateEmployeeMessage());
            CancelCommand.Execute(null);
        }
    }
}
