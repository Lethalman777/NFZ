using Microsoft.EntityFrameworkCore;
using NFZ.Entities;

namespace NFZ.Seeder
{
    public class DocumentSeeder
    {
        private readonly NFZDbContext dbContext;

        public DocumentSeeder(NFZDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                var pending = this.dbContext.Database.GetPendingMigrations();
                if (pending != null && pending.Any())
                {
                    this.dbContext.Database.Migrate();
                }

                if (!dbContext.workers.Any())
                {
                    var workers = GetWorkers();
                    dbContext.workers.AddRange(workers);
                    dbContext.SaveChanges();
                }

                if (!dbContext.products.Any())
                {
                    var products = GetProducts();
                    dbContext.products.AddRange(products);
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
                {
                    new Product()
                    {
                        Name = "Worek Cementu",
                        Price = 100,
                        isCountable = true,
                        Count = 30,
                        Vat = 23
                    },
                    new Product()
                    {
                        Name = "Blacha Falowana",
                        Price = 150,
                        isCountable = true,
                        Count = 30,
                        Vat = 14
                    },
                    new Product()
                    {
                        Name = "Węgiel",
                        Price = 400,
                        isCountable = false,
                        Count = 30,
                        Vat = 23
                    },
                    new Product()
                    {
                        Name = "Betonowy Bloczek",
                        Price = 50,
                        isCountable = true,
                        Count = 30,
                        Vat = 14
                    }
                };
        }

        private IEnumerable<Worker> GetWorkers()
        {
            return new List<Worker>()
                {
                    new Worker()
                    {
                        Name = "Bogusław",
                        Surname = "Radziwił",
                        Login = "Wiesiek",
                        Password = "Traktor"
                    }
                };
        }
    }
}
