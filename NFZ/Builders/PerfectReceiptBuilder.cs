using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Factory;

namespace NFZ.Builders
{
    public class PerfectReceiptBuilder : PerfectDocumentBuilder
    {
        DocumentModel receiptDto;
        Iterator iterator;
        public Receipt receipt;

        public PerfectReceiptBuilder(DocumentModel receiptDto, Iterator iterator)  //Konstruktor
        {
            this.receiptDto = receiptDto;
            this.iterator = iterator;
        }

        public override void BuildDocument()         //Nadpisanie metody BuildDocument znajdującej się w klasie
        {                                            //PerfectDocumentBuilder
            receipt = new Receipt();
        }

        public override Receipt GetDocument() //Nadpisanie metody getDocument z kalsy PerfectDocumentBuilder
        {
            return receipt;
        }

        private decimal TotalPrice(List<Product> products)  //Wyliczenie ostatecznej ceny na paragonie
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
            receipt.Price = TotalPrice(receiptDto.Products);

            var r = new Random();
            receipt.Products = new List<ReceiptProduct>();

            foreach (var product in receiptDto.Products)
            {
                receipt.Products.Add(new ReceiptProduct()
                {
                    ReceiptMany = receipt,
                    ProductId = product.Id,
                    ProductMany = product,
                    ProductCount = receiptDto.ProductCounts[receiptDto.Products.IndexOf(product)]
                });
            }
        }

        public override void SetCompanyInfo()
        {
            string country = receiptDto.Country;
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
            receipt.Department = country;
            receipt.Address = department.Address;
        }

        public override void SetClientInfo()
        {
            receipt.ClientName = receiptDto.ClientName;
        }

        public override void SetOrderInfo()
        {
            receipt.Date = DateTime.Now;
            receipt.Number = receiptDto.Number;
        }

        public override void SetWorkerInfo()
        {
            receipt.Worker = iterator.dbservice.GetWorker(1);
            receipt.WorkerId = 1;
        }
    }
}
