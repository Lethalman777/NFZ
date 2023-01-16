using NFZ.Entities;
using NFZ.Models;

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

        public Product GetProductName(string name)
        {
            return _dbContext.products.FirstOrDefault(v => v.Name == name);
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
                var document = _dbContext.invoices.FirstOrDefault(p => p.Number == id);
                if (document != null)
                {
                    document.Products = _dbContext.invoiceProducts.ToList();
                    document.Products.RemoveAll(v => v.InvoiceId != document.Id);
                    foreach(var product in document.Products)
                    {
                        product.ProductMany = _dbContext.products.FirstOrDefault(v=>v.Id == product.ProductId);
                    }
                }

                return document;
            }
            else
            {
                var document = _dbContext.receipts.FirstOrDefault(p => p.Number == id);
                if (document != null)
                {
                    document.Products = _dbContext.receiptProducts.ToList();
                    document.Products.RemoveAll(v => v.ReceiptId != document.Id);
                    foreach (var product in document.Products)
                    {
                        product.ProductMany = _dbContext.products.FirstOrDefault(v => v.Id == product.ProductId);
                    }
                }

                return document;
            }          
        }

        public List<Product> GetProductsDocument(int id, bool isInvoice)
        {
            if (isInvoice)
            {
                var products = _dbContext.invoiceProducts.ToList();
                products.RemoveAll(v => v.InvoiceId != id);
                List<Product> list = new List<Product>();
                foreach(var product in products)
                {
                    list.Add(_dbContext.products.FirstOrDefault(v => v.Id == product.ProductId));
                }
               
                return list;
            }
            else
            {
                var products = _dbContext.receiptProducts.ToList();
                products.RemoveAll(v => v.ReceiptId != id);
                List<Product> list = new List<Product>();
                foreach (var product in products)
                {
                    list.Add(_dbContext.products.FirstOrDefault(v => v.Id == product.ProductId));
                }

                return list;
            }
        }

        public List<Document> GetMixedDocuments()
        {
            var list = new List<Document>();
            foreach(var item in _dbContext.invoices)
            {
                list.Add(item);
            }
            foreach (var item in _dbContext.receipts)
            {
                list.Add(item);
            }

            return list;
        }

        public void AddInvoice(Invoice invoice)
        {          
            _dbContext.invoices.Add(invoice);         
            _dbContext.SaveChanges();
            
            foreach(var product in invoice.Products)
            {
                var entity = _dbContext.products.FirstOrDefault(v => v.Id == product.ProductId);
                if (entity.Count - product.ProductCount < 0)
                {                    
                    entity.Count -= product.ProductCount;
                    _dbContext.products.Update(entity);
                }
            }

            _dbContext.SaveChanges();
        }

        public void AddReceipt(Receipt receipt)
        {
            _dbContext.receipts.Add(receipt);
            _dbContext.SaveChanges();

            foreach (var product in receipt.Products)
            {
                var entity = _dbContext.products.FirstOrDefault(v => v.Id == product.ProductId);
                if (entity.Count - product.ProductCount < 0)
                {
                    entity.Count -= product.ProductCount;
                    _dbContext.products.Update(entity);
                }
            }

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

        public List<Order> GetOrders()
        {
            return _dbContext.orders.ToList();
        }

        public List<Product> GetProductOrder(int id)
        {
            var orders = new List<Product>();
            var order = _dbContext.orders.FirstOrDefault(r => r.Id == id);

            order.Products = _dbContext.orderProducts.ToList();
            order.Products.RemoveAll(v => v.OrderId != id);

            foreach(var product in order.Products)
            {
                orders.Add(product.ProductMany);
            }

            return orders;
        }

        public Order GetOrder(int id)
        {
            var order = _dbContext.orders.FirstOrDefault(r => r.Id == id);

            order.Products = _dbContext.orderProducts.ToList();
            order.Products.RemoveAll(v=>v.OrderId != id);

            return order;
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
