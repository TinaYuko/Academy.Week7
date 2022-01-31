using Avanade.Allocation.Core.BL;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.WPF.Messaging.Employee;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeEditorViewModel: ViewModelBase
    {
        public ICommand CreateEmployee { get; set; }

        public ObservableCollection<EmployeeRowViewModel> EmployeeSource;
        public ICollectionView employees;
        public ICollectionView Employees
        {
            get { return employees; }
            set { employees = value; RaisePropertyChanged(); }
        }

        public ICommand LoadEmployeesCommand { get; set; }

        public EmployeeEditorViewModel()
        {
            CreateEmployee = new RelayCommand(() => ExecuteShowCreateEmployee());
            LoadEmployeesCommand = new RelayCommand(() => ExecuteLoadEmployee());
            
            //inizializzo le liste
            EmployeeSource = new ObservableCollection<EmployeeRowViewModel>();
            employees= new CollectionView(EmployeeSource);
            
            LoadEmployeesCommand.Execute(null);
        }

        private void ExecuteLoadEmployee()
        {
            //Inizializzo il bl
            //istanzio il repo
            IEmployeeRepository repo = new EmployeeRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            var employees=layer.FetchAllEmployees();
            //pulisco la lista sorgente
            EmployeeSource.Clear();

            //per ciascun dipendente mi creo una riga di tipo employeeRowviewmodel

            foreach (Employee item in employees)
            {
                var vmEmpRow= new EmployeeRowViewModel(item);
                EmployeeSource.Add(vmEmpRow);
            }
        }

        private void ExecuteShowCreateEmployee()
        {
            Messenger.Default.Send(new ShowCreateEmployeeMessage());

        }
    }
}
