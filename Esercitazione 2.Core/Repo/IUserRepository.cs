using Esercitazione_2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_2.Core.Repo
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
    }
}
