﻿using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Builders
{
    public class PerfectInvoiceBuilder : PerfectDocumentBuilder
    {
        DocumentModel invoiceDto;
        public Invoice invoice;

        public PerfectInvoiceBuilder(DocumentModel invoiceDto)
        {
            this.invoiceDto = invoiceDto;
        }

        public override void BuildDocument()
        {
            invoice = new Invoice()
            {
                Worker = new Worker(),
                Products = new List<Product>(invoiceDto.Products),
                Price = TotalPrice(invoiceDto.Products),
                PaymentDate = new DateTime(),
                ClientName = invoiceDto.ClientName,
                Number = invoiceDto.Number,
                NIP = invoiceDto.NIP,
                AccountNr = invoiceDto.AccountNr,
                Date = new DateTime()
            };
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
