using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Builders
{
    public class PerfectReceiptBuilder : PerfectDocumentBuilder
    {
        DocumentModel receiptDto;
        Worker worker;
        public Receipt receipt;

        public PerfectReceiptBuilder(DocumentModel receiptDto, Worker worker)
        {
            this.receiptDto = receiptDto;
            this.worker = worker;
        }

        public override void BuildDocument()
        {
            receipt = new Receipt()
            {
                Worker = new Worker()
                {
                    Name = worker.Name,
                    Surname = worker.Surname,
                    Login = worker.Login,
                    Password = worker.Password
                },
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
