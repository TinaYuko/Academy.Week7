using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercitazione1.Entities
{
    public class ProductRepoMock: IProductRepo
    {
        private List<Product> products = new List<Product>()
        {
            new Product() { Name= "Laptop", Description="Pc Asus", Price=799},
            new Product() { Name= "Modem", Description="Wifi NetGear 5.0", Price=29}
        };

        public List<Product> GetAll()
        {
            return products;
        }


    }
}
