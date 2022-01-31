using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Storage
{
    public class AllocationMockStorage
    {
        public static IList<User> Users { get; set; }
        public static IList<Employee> Employees { get; set; }

        public static void Initialize()
        {
            #region USERS
            Users = new List<User>();
            Users.Add(new User
            {
                Id = 1,
                UserName = "lino.banfi",
                Password = "12345",
                Email = "lino.bb@gmail.com"
            });
            Users.Add(new User
            {
                Id = 2,
                UserName = "orietta.b",
                Password = "12345!!",
                Email = "oriettinarossococacola@gmail.com"
            });
            Users.Add(new User
            {
                Id = 1,
                UserName = "pippofranco",
                Password = "123aabb",
                Email = "chefico@gmail.com"
            });
            #endregion USERS

            #region EMPLOYEES
            Employees = new List<Employee>();
            Employees.Add(
                new Employee 
                { 
            
                    Id=123,
                    FirstName="Pippo",
                    LastName="Franco",
                    Email="pippo@gmail.com",
                    DateOfBirth=new DateTime(1940,11,10),
                    Salary=1000.00,
                    IsEnabled=true
                });
            #endregion EMPLOYEES
        }
    }
}
