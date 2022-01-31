using Esercitazione_2.Core.Entities;
using Esercitazione_2.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_2.Core.Mock.Repo
{
    public class ProductRepositoryMock : IProductRepository
    {
        public IList<Product> GetAll()
        {
            return AllocationMockStorage.Products;

        }
    }
}
