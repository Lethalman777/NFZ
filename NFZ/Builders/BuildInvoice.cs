using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Services;

namespace NFZ.Builders
{
    public class BuildInvoice : DocumentBuilder
    {
        OrderModel order;
        Iterator iterator;
        DatabaseService databaseService;
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
                ProductIds = new List<int>(),
                ProductCounts = new List<float>(),
                Products = new List<Product>(order.Products),
                Price = TotalPrice(order.Products),
                PaymentDate = DateTime.Now,
                ClientName = order.ClientName,
                Number = GetNumber(),
                isInvoice = true,
                SelectName = ""
            };
            var r = new Random();
            foreach(var product in order.Products)
            {
                invoiceDto.ProductIds.Add(product.Id);
                invoiceDto.ProductCounts.Add((float)r.Next(1,(int)product.Count));
            }
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
