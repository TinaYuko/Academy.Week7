using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Repositories
{
    public interface IEmployeeRepository
    {
        IList<Employee> FetchAll();
        Employee GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee, Employee entity);
        void Delete(Employee employee);
    }
}
