using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.BindingDemo.Entities
{
    public class RepoPersonMock : IRepoPerson
    {
        private IList<Person> people = new List<Person>()
        { new Person {FirstName ="Orietta", LastName ="Berti"},
          new Person {FirstName ="Pippo", LastName ="Franco"},
          new Person {FirstName ="Giancarlo", LastName ="Magalli"}
        };
        public IList<Person> GetAll()
        {
            return people;
        }
    }
}
