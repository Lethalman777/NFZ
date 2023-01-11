using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Builders
{
    public class PerfectReceiptBuilder : PerfectDocumentBuilder
    {
        DocumentModel receiptDto;
        public Receipt receipt;

        public PerfectReceiptBuilder(DocumentModel receiptDto)
        {
            this.receiptDto = receiptDto;
        }

        public override void BuildDocument()
        {
            receipt = new Receipt()
            {
                Worker = new Worker(),
                Products = new List<Product>(receiptDto.Products),
                Price = TotalPrice(receiptDto.Products),
                Number = receiptDto.Number,
                Date = new DateTime()
            };
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
