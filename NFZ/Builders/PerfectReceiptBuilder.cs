using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

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
            receipt = new Receipt()
            {
                Worker = iterator.dbservice.GetWorker(1),
                WorkerId = iterator.dbservice.GetWorker(1).Id,
                Products = new List<ReceiptProduct>(),
                Price = receiptDto.Price,
                Number = receiptDto.Number,
                ClientName = receiptDto.ClientName,
                Date = receiptDto.Date
            };

            foreach (var product in receiptDto.ProductIds)
            {
                receipt.Products.Add(new ReceiptProduct()
                {
                    ReceiptMany = receipt,
                    ProductMany = iterator.dbservice.GetProduct(product),
                    ProductCount = receiptDto.ProductCounts[receiptDto.ProductIds.IndexOf(product)]
                });
            }
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
    }
}
