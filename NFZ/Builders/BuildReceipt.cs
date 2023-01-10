using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public class BuildReceipt : DocumentBuilder
    {
        Order order;
        Iterator iterator;
        public ReceiptDto receiptDto;

        public BuildReceipt(Order order, Iterator iterator)
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()
        {
            receiptDto = new ReceiptDto()
            {
                Worker = new Worker(),
                Products = new List<Product>(order.Products),
                Price = TotalPrice(order.Products),
                Number = GetNumber()
            };
        }

        public override DocumentDto GetTemplate()
        {
            return receiptDto;
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
            iterator.isInvoice = false;

            while (!iterator.isDone())
            {
                iterator.currentNumber++;
            }

            return iterator.currentNumber + 1;
        }
    }
}
