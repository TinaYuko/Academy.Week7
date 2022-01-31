using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercitazione1.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public override string ToString()
        {
            return $"{Name} - {Description}: {Price} euro";
        }
    }
}
