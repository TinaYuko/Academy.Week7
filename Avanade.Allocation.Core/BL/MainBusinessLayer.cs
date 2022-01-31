using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.BL
{
    public class MainBusinessLayer
    {
        private IEmployeeRepository employeeRepository;

        public MainBusinessLayer(IEmployeeRepository repoEmp)
        {
            employeeRepository = repoEmp;
        }

        //restituisce lista dipendenti
        public IList<Employee> FetchAllEmployees()
        {
            return employeeRepository.FetchAll();
        }
        public Response CreateEmployee(Employee entity)
        {
            //valido l'argomento
            if (entity==null)
            {
                return new Response { Success = false, Message = "Invalid Entity" };
            }
            if (entity.Salary <0.0)
            {
                return new Response { Success = false, Message = "Salary must be positive" };
            }

            employeeRepository.Create(entity);
            return new Response { Success = true, Message = $"Employee {entity.FirstName} {entity.LastName} added correctly" };
        }

        public Response DeleteEmployee(Employee entity)
        {
            if (entity == null)
            {
                return new Response { Success = false, Message = "Invalid Entity" };
            }
            if (entity.Id<0)
            {
                return new Response { Success = false, Message = "Invalid Id" };

            }
            var employeeToDelete=FetchAllEmployees().FirstOrDefault(x=> x.Id==entity.Id); ;
            if (employeeToDelete==null)
            {
                return new Response { Success = false, Message = $"No employee with Id: {entity.Id}" };
            }
            employeeRepository.Delete(employeeToDelete);
            return new Response { Success = true, Message = "Employee deleted correctly" };
        }

        public Response UpdateEmployee(Employee entity)
        {
            //Validazione argomenti
            if (entity == null)
                return new Response() { Success = false, Message = "Incorrect entity" };

            //CERCARE L'IMPIEGATO DA MODIFICARE
            var employeeToUpdate = FetchAllEmployees().FirstOrDefault(x => x.Id == entity.Id);

            //Se invece la lista è vuota significa che è andato tutto bene
            employeeRepository.Update(employeeToUpdate, entity);

            //Emetto comunque la lista (vuota) per segnalare che è andato tutto bene
            return new Response() { Success = true, Message = "Employee updated" };
        }
    }
}
