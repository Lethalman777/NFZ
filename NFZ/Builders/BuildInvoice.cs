using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public class BuildInvoice : DocumentBuilder
    {
        Order order;
        Iterator iterator;
        public InvoiceDto invoiceDto;

        public BuildInvoice(Order order, Iterator iterator)
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()
        {
            invoiceDto = new InvoiceDto()
            {
                Worker = new Worker(),
                Products = new List<Product>(order.Products),
                Price = TotalPrice(order.Products),
                PaymentDate = new DateTime(),
                ClientName = order.ClientName,
                Number = GetNumber()
            };
        }

        public override DocumentDto GetTemplate()
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
