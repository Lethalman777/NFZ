using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Services;

namespace NFZ.Builders
{
    public class BuildReceipt : DocumentBuilder
    {
        OrderModel order;
        Iterator iterator;
        public DocumentModel receiptDto;

        public BuildReceipt(OrderModel order, Iterator iterator)
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()
        {          
            receiptDto = new DocumentModel()
            {
                Products = new List<Product>(order.Products),
                Price = TotalPrice(order.Products),
                Number = GetNumber(),
                isInvoice = false,
                SelectName = "",
                ProductIds = new List<int>()
            };

            var r = new Random();
            
            foreach (var product in order.Products)
            {
                receiptDto.ProductIds.Add(product.Id);
                receiptDto.ProductCounts.Add((float)r.Next(1, (int)product.Count));
            }
        }

        public override DocumentModel GetTemplate()
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
            iterator.isInvoice = true;

            while (!iterator.isDone())
            {
                iterator.Next();
            }

            return iterator.currentNumber + 1;
        }
    }
}
