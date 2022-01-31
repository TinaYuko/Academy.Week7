using Esercitazione_2.Core.Entities;

namespace Esercitazione_2.Core.Mock
{
    public static class AllocationMockStorage
    {
        public static IList<User> Users { get; set; }
        public static IList<Product> Products { get; set; }

        public static void Initialize()
        {
            //creazione della lista vuota
            Users = new List<User>();
            Products = new List<Product>();

            //Aggiunta di utenti base
            Users.Add(new User
            {
                Id = 1111,
                UserName = "lino.banfi",
                Password = "12345",
                Email = "lino@gmail.com"
            });
            Users.Add(new User
            {
                Id = 2222,
                UserName = "orietta.berti",
                Password = "abcdefh",
                Email = "oriettarossococacola@gmail.com"
            });

            Products.Add(new Product
            {
                Name = "Smartphone",
                Description = "iPhone XR 128GB",
                Price = 450.45
            });
            Products.Add(new Product
            {
                Name = "Laptop",
                Description = "Dell 1742HF",
                Price = 890.90
            });
        }
    }
}