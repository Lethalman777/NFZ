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

        public BuildReceipt(OrderModel order, Iterator iterator) //Konstruktor
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()    //Nadpisanie metody BuildTemplate znajdującej się w klasie
        {                                       //DocumentBuilder
            receiptDto = new DocumentModel();
        }

        public override DocumentModel GetTemplate()     //Nadpisanie metody pobrania szablonu faktury
        {
            return receiptDto;
        }

        private decimal TotalPrice(List<Product> products) //Wyliczenie kwoty znajdującej się na paragonie 
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }

            return total;
        }

        private int GetNumber()             //Metoda zwraca obecny numer na iteratorze
        {                                   //Iterator jest użyty aby znaleźc nowy numer faktury
            iterator.isInvoice = true;

            while (!iterator.isDone())
            {
                iterator.Next();
            }

            return iterator.currentNumber + 1;
        }

        public override void SetProducts()
        {
            receiptDto.ProductCounts = new List<float>();
            receiptDto.Products = new List<Product>(order.Products);
            receiptDto.ProductIds = new List<int>();
            receiptDto.Price = TotalPrice(receiptDto.Products);

            var r = new Random();

            foreach (var product in order.Products)
            {
                receiptDto.ProductIds.Add(product.Id);
                receiptDto.ProductCounts.Add((float)r.Next(1, (int)product.Count));
            }
        }

        public override void SetCompanyInfo()
        {
            
        }

        public override void SetClientInfo()
        {
            receiptDto.ClientName = order.ClientName;
        }

        public override void SetOrderInfo()
        {
            receiptDto.Date = DateTime.Now;
            receiptDto.PaymentDate = DateTime.Now.AddDays(30);
            receiptDto.isInvoice = false;
            receiptDto.Number = GetNumber();
        }
    }
}
