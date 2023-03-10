using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Services;
using NFZ.Factory;

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
            invoiceDto = new DocumentModel();
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

        public override void SetProducts()
        {
            invoiceDto.ProductCounts = new List<float>();
            invoiceDto.Products = new List<Product>(order.Products);
            invoiceDto.ProductIds = new List<int>();
            invoiceDto.Price = TotalPrice(invoiceDto.Products);
           
            var r = new Random();
            foreach (var product in order.Products)
            {
                invoiceDto.ProductIds.Add(product.Id);
                invoiceDto.ProductCounts.Add((float)r.Next(1, (int)product.Count));
            }
        }

        public override void SetCompanyInfo()
        {
            string country = order.Country;
            Department department = null;
            DepartmentManager departmentManager;
            switch (country)
            {
                case "Poland": 
                    departmentManager = new PolandDepartmentManager();
                    department = departmentManager.GetDepartment(); 
                    break;
                case "Germany":
                    departmentManager = new GermanyDepartmentManager();
                    department = departmentManager.GetDepartment();
                    break;
                case "Asia":
                    departmentManager = new AsiaDepartmentManager();
                    department = departmentManager.GetDepartment();
                    break;
            }
            invoiceDto.Country = country;
            invoiceDto.NIP = department.NIP;
            invoiceDto.AccountNr = department.AccountNr;
            invoiceDto.Address = department.Address;
        }

        public override void SetClientInfo()
        {
            invoiceDto.ClientName = order.ClientName;
        }

        public override void SetOrderInfo()
        {
            invoiceDto.Date = DateTime.Now;
            invoiceDto.PaymentDate = DateTime.Now.AddDays(30);
            invoiceDto.isInvoice = true;
            invoiceDto.Number = GetNumber();
        }
    }
}
