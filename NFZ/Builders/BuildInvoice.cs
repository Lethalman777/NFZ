﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public BuildInvoice(OrderModel order, Iterator iterator)  //Konstruktor
        {
            this.order = order;
            this.iterator = iterator;
        }

        public override void BuildTemplate()        //Nadpisanie metody BuildTemplate znajdującej się w klasie 
        {                                           //DocumentBuilder 
            invoiceDto = new DocumentModel()
            {
                ProductIds = new List<int>(),
                ProductCounts = new List<float>(),
                Products = new List<Product>(order.Products),
                Price = order.Price,
                PaymentDate = DateTime.Now.AddDays(30),
                Date = DateTime.Now,
                ClientName = order.ClientName,
                Number = GetNumber(),
                isInvoice = true,
                SelectName = "",
                NIP = 66666666,
                AccountNr = 60670000
            };
            var r = new Random();
            foreach(var product in order.Products)
            {
                invoiceDto.ProductIds.Add(product.Id);
                invoiceDto.ProductCounts.Add((float)r.Next(1,(int)product.Count));
            }
        }

        public override DocumentModel GetTemplate()     //Nadpisanie metody pobrania szablonu faktury
        {
            return invoiceDto;
        }

        private decimal TotalPrice(List<Product> products)  //Wyliczenie całkowitej kwoty na fakturze
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }

            return total;
        }

        private int GetNumber()         //Metoda zwraca obecny numer na iteratorze
        {                               //Iterator jest użyty aby znaleźc nowy numer faktury
            iterator.isInvoice = true;

            while (!iterator.isDone())
            {
                iterator.Next();
            }

            return iterator.currentNumber + 1;
        }
    }
}
