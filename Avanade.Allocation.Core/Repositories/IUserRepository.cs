using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Repositories
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
    }
}
