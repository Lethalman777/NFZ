using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public class BuildInvoice : DocumentBuilder
    {
        OrderModel order;
        Iterator iterator;
        public DocumentModel invoiceDto;

        public BuildInvoice(OrderModel order, Iterator iterator)
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()
        {
            invoiceDto = new DocumentModel()
            {
                Worker = new Worker(),
                Products = new List<Product>(order.Products),
                Price = TotalPrice(order.Products),
                PaymentDate = new DateTime(),
                ClientName = order.ClientName,
                Number = GetNumber(),
                isInvoice = true
            };
        }

        public override DocumentModel GetTemplate()
        {
            return invoiceDto;
        }

        private decimal TotalPrice(List<Product> products)
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }

            return total;
        }

        private int GetNumber()
        {
            iterator.isInvoice = true;

            while (!iterator.isDone())
            {
                iterator.Next();
            }

            return iterator.currentNumber + 1;
        }
    }
}
