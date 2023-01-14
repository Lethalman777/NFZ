using NFZ.Entities;

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
        IEnumerable<Worker> GetWorkers();
        void RemoveDocument(int Id, bool isInvoice);
        void RemoveOrder(int Id);
        void RemoveProduct(int Id);
        void RemoveWorker(int Id);
    }
}