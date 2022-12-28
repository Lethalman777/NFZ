using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Builders
{
    public class BuildInvoice : Builder
    {
        public InvoiceDto document;

        public BuildInvoice(InvoiceDto document)
        {
            this.document = document;
        }

        public override Document BuildDocument()
        {
            throw new NotImplementedException();
            var invoice = new Invoice()
            {
                Worker = document.Worker,
                Products = new List<Product>(document.Products),
                Price = document.Price,
                PaymentDate = document.PaymentDate,
                ClientName = document.ClientName,
                NIP = document.NIP,
                AccountNr = document.AccountNr
            };

            return invoice;
        }
    }
}
