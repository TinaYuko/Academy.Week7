using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Repositories
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {

        public void Create(Employee employee)
        {
            var newId = AllocationMockStorage.Employees.Max(e => e.Id) + 1;
            employee.Id = newId;
            AllocationMockStorage.Employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            var existingEmployee = AllocationMockStorage.Employees.FirstOrDefault(e => e.Id == employee.Id);
            AllocationMockStorage.Employees.Remove(existingEmployee);   
        }

        public IList<Employee> FetchAll()
        {
            return AllocationMockStorage.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            var existingEmployee=AllocationMockStorage.Employees.FirstOrDefault(e=>e.Id==employee.Id);
            //rimuovo e riaggiungo l'elemento
            AllocationMockStorage.Employees.Remove(existingEmployee);
            AllocationMockStorage.Employees.Add(employee);
        }

        public void Update(Employee employeeVecchio, Employee entityNuovo)
        {
            employeeVecchio = AllocationMockStorage.Employees.FirstOrDefault(e => e.Id == entityNuovo.Id);
            //rimuovo e riaggiungo l'elemento
            AllocationMockStorage.Employees.Remove(employeeVecchio);
            AllocationMockStorage.Employees.Add(entityNuovo);

        }
    }
}
