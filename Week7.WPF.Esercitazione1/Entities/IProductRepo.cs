using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercitazione1.Entities
{
    public interface IProductRepo
    {
        public List<Product> GetAll();
        
    }
}
