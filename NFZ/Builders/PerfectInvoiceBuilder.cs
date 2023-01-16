using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public class PerfectInvoiceBuilder : PerfectDocumentBuilder
    {
        DocumentModel invoiceDto;
        Iterator iterator;
        public Invoice invoice;

        public PerfectInvoiceBuilder(DocumentModel invoiceDto, Iterator iterator)
        {
            this.invoiceDto = invoiceDto;
            this.iterator = iterator;
        }

        public override void BuildDocument()
        {
            invoice = new Invoice()
            {
                Worker = iterator.dbservice.GetWorker(1),
                WorkerId = iterator.dbservice.GetWorker(1).Id,
                Price = TotalPrice(invoiceDto.Products),
                PaymentDate = new DateTime(),
                ClientName = invoiceDto.ClientName,
                Number = invoiceDto.Number,
                NIP = invoiceDto.NIP,
                AccountNr = invoiceDto.AccountNr,
                Date = new DateTime(),
                Products = new List<InvoiceProduct>()
            };

            foreach(var product in invoiceDto.ProductIds)
            {
                invoice.Products.Add(new InvoiceProduct()
                {
                    InvoiceMany = invoice,
                    ProductMany = iterator.dbservice.GetProduct(product),
                    ProductCount = invoiceDto.ProductCounts[invoiceDto.ProductIds.IndexOf(product)]
                });
            }           
        }

        public override Invoice GetDocument()
        {
            return invoice;
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
