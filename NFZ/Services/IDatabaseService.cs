using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Services
{
    public interface IDatabaseService
    {
        void AddInvoice(Invoice invoice);
        void AddReceipt(Receipt receipt);
        void AddOrder(Order order);
        void AddProduct(Product product);
        void AddWorker(Worker worker);
        Document GetDocument(int id, bool isInvoice);
        List<Document> GetMixedDocuments();
        Order GetOrder(int id);
        IEnumerable<Document> GetDocuments(bool isInvoice);
        List<Order> GetOrders();
        Product GetProduct(int id);
        List<Product> GetProducts();
        Worker GetWorker(int id);
        List<Worker> GetWorkers();
        void RemoveDocument(int Id, bool isInvoice);
        void RemoveOrder(int Id);
        void RemoveProduct(int Id);
        void RemoveWorker(int Id);
        Product GetProductName(string selectName);
        List<Product> GetProductOrder(int id);
        Worker GetLogin(string login);
    }
}