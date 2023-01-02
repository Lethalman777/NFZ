using NFZ.Entities;

namespace NFZ.Services
{
    public interface IDatabaseService
    {
        void AddOrder(Order order);
        void AddProduct(Product product);
        void AddWorker(Worker worker);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Worker GetWorker(int id);
        IEnumerable<Worker> GetWorkers();
        void RemoveOrder(int Id);
        void RemoveProduct(int Id);
        void RemoveWorker(int Id);
    }
}