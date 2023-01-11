using NFZ.Entities;

namespace NFZ.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly NFZDbContext _dbContext;

        public DatabaseService(NFZDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetProducts()
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
            return _dbContext.workers;
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

        public Document GetDocument(int id, bool isInvoice)
        {
            if (isInvoice)
            {
                return _dbContext.invoices.FirstOrDefault(p => p.Number == id);
            }
            else
            {
                return _dbContext.receipts.FirstOrDefault(p => p.Number == id);
            }          
        }

        public void AddInvoice(Invoice invoice)
        {          
            _dbContext.invoices.Add(invoice);         
            _dbContext.SaveChanges();
        }

        public void AddReceipt(Receipt receipt)
        {
            _dbContext.receipts.Add(receipt);
            _dbContext.SaveChanges();
        }

        public void RemoveDocument(int Id, bool isInvoice)
        {
            if (isInvoice)
            {
                var document = _dbContext.invoices.FirstOrDefault(r => r.Id == Id);

                _dbContext.Remove(document);
            }
            else
            {
                var document = _dbContext.receipts.FirstOrDefault(r => r.Id == Id);

                _dbContext.Remove(document);
            }
           

            _dbContext.SaveChanges();
        }

        public IEnumerable<Document> GetDocuments(bool isInvoice)
        {
            if(isInvoice)
            {
                return _dbContext.invoices;
            }
            else
            {
                return _dbContext.receipts;
            }           
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.orders;
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
