using NFZ.Entities;

namespace NFZ.Services
{
    public class DatabaseService
    {
        private readonly NFZDbContext _dbContext;

        public DatabaseService(NFZDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.products.ToList();
        }

        public Product GetProduct(int id)
        {
            var product = _dbContext.products.FirstOrDefault(p => p.Id == id);

            return product;
        }

        public void AddProduct(Product product)
        {
            _dbContext.products.Add(product);
            _dbContext.SaveChanges();
        }

        public void RemoveProduct(int Id)
        {
            var product = _dbContext.products.FirstOrDefault(r => r.Id == Id);

            _dbContext.Remove(product);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Worker> GetWorkers()
        {
            return _dbContext.workers.ToList();
        }

        public Worker GetWorker(int id)
        {
            return _dbContext.workers.FirstOrDefault(p => p.Id == id);
        }

        public void AddWorker(Worker worker)
        {
            _dbContext.workers.Add(worker);
            _dbContext.SaveChanges();
        }

        public void RemoveWorker(int Id)
        {
            var worker = _dbContext.workers.FirstOrDefault(r => r.Id == Id);

            _dbContext.Remove(worker);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.orders.ToList();
        }

        public Order GetOrder(int id)
        {
            return _dbContext.orders.FirstOrDefault(p => p.Id == id);
        }

        public void AddOrder(Order order)
        {
            _dbContext.orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void RemoveOrder(int Id)
        {
            var order = _dbContext.orders.FirstOrDefault(r => r.Id == Id);

            _dbContext.Remove(order);

            _dbContext.SaveChanges();
        }
    }
}
