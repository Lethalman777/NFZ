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

        public PerfectReceiptBuilder(DocumentModel receiptDto, Iterator iterator)
        {
            this.receiptDto = receiptDto;
            this.iterator = iterator;
        }

        public override void BuildDocument()
        {
            receipt = new Receipt()
            {
                Worker = iterator.dbservice.GetWorker(1),
                WorkerId = iterator.dbservice.GetWorker(1).Id,
                Products = new List<ReceiptProduct>(),
                Price = TotalPrice(receiptDto.Products),
                Number = receiptDto.Number,
                Date = new DateTime()
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

        public override Receipt GetDocument()
        {
            return receipt;
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
    }
}
