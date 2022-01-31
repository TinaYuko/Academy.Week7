using Avanade.Allocation.Core.BL;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.WPF.Messaging.Employee;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeRowViewModel: ViewModelBase
    {
        private Employee item;
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
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public EmployeeRowViewModel()
        {
            UpdateCommand = new RelayCommand(() => ExecuteUpdate());
            DeleteCommand = new RelayCommand(() => ExecuteDelete());
        }
        public EmployeeRowViewModel(Employee item): this()
        {
            //Associo il dipendente trovato e associo la mia view
            FirstName = item.FirstName;
            LastName = item.LastName;
            this.item = item;
        }

        private void ExecuteDelete()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Confirm Delete",
                Content = "Are u sure?",
                Icon= MessageBoxImage.Question,
                Buttons=MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult result)
        {
            if (result==MessageBoxResult.Yes)
            {
                var layer = new MainBusinessLayer(new EmployeeRepositoryMock());

                var response= layer.DeleteEmployee(item);

                if (!response.Success)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Message,
                        Icon= MessageBoxImage.Error,
                        Buttons=MessageBoxButton.OK,
                    });
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    { 
                        Title="Deletion Confirmed",
                        Content=response.Message,
                        Icon=MessageBoxImage.Information
                    });
                }
            }
        }

        private void ExecuteUpdate()
        {
            Messenger.Default.Send(new ShowUpdateEmployeeMessage { Entity = item });
        }
    }
}