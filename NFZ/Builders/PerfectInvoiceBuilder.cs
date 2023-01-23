using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Factory;

namespace NFZ.Builders
{
    public class PerfectInvoiceBuilder : PerfectDocumentBuilder
    {
        DocumentModel invoiceDto;
        Iterator iterator;
        public Invoice invoice;

        public PerfectInvoiceBuilder(DocumentModel invoiceDto, Iterator iterator) //Konstruktor
        {
            this.invoiceDto = invoiceDto;
            this.iterator = iterator;
        }

        public override void BuildDocument()   //Nadpisanie metody BuildDocument znajdującej się w klasie
        {                                      //PerfectDocumentBuilder
            invoice = new Invoice();

        }

        public override Invoice GetDocument()  //Nadpisanie metody getDocument z kalsy PerfectDocumentBuilder
        {
            return invoice;
        }

        private decimal TotalPrice(List<Product> products)  //Wyliczenie końcowej ceny na fakturze
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }

            return total;
        }

        public override void SetProducts()
        {
            invoice.Price = TotalPrice(invoiceDto.Products);
            invoice.Products = new List<InvoiceProduct>();

            var r = new Random();
            foreach (var product in invoiceDto.Products)
            {
                invoice.Products.Add(new InvoiceProduct()
                {
                    InvoiceMany = invoice,
                    ProductId = product.Id,
                    ProductMany = product,
                    ProductCount = invoiceDto.ProductCounts[invoiceDto.Products.IndexOf(product)]
                });
            }
        }

        public override void SetCompanyInfo()
        {
            string country = invoiceDto.Country;
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
            invoice.Department = country;
            invoice.NIP = department.NIP;
            invoice.AccountNr = department.AccountNr;
            invoice.Address = department.Address;
        }

        public override void SetClientInfo()
        {
            invoice.ClientName = invoiceDto.ClientName;
        }

        public override void SetOrderInfo()
        {
            invoice.Date = DateTime.Now;
            invoice.PaymentDate = DateTime.Now.AddDays(30);
            invoice.Number = invoiceDto.Number;
        }

        public override void SetWorkerInfo()
        {
            invoice.Worker = iterator.dbservice.GetWorker(1);
            //invoice.WorkerId = 1;
        }
    }
}
