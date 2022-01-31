using Esercitazione_2.Core.Entities;
using Esercitazione_2.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_2.Core.Mock.Repo
{
    public class UserRepositoryMock : IUserRepository
    {
        public User GetByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            return AllocationMockStorage.Users.Where(u => u.UserName.Equals(userName)).FirstOrDefault();
        }
    }
}
