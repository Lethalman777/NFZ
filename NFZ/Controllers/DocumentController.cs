using Microsoft.AspNetCore.Mvc;
using NFZ.Builders;
using NFZ.Entities;
using NFZ.Models;
using NFZ.Services;

namespace NFZ.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDatabaseService dbservice;
        private readonly IDocuments documents;

        public DocumentController(IDatabaseService dbservice, IDocuments documents)
        {
            this.dbservice = dbservice;
            this.documents = documents;
        }

        [Route("Orders")]
        public IActionResult Orders()
        {
            //var orders = dbservice.GetOrders().ToList();
            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    ClientName = "kola",
                    Products = new List<Product>(dbservice.GetProducts()),
                    isInvoke = true
                }
            };
            return View(orders);
        }

        [Route("Invoice")]
        public IActionResult Invoice(Order order)
        {
            var document = documents.GetTemplate(order);

            return View(document);
        }

        [Route("SaveInvoice")]
        public IActionResult SaveInvoice(InvoiceDto invoice)
        {
            var Invoice = new Invoice()
            {
                ClientName = invoice.ClientName,
                PaymentDate = invoice.PaymentDate,
                Price = invoice.Price,
                NIP = invoice.NIP,
                AccountNr = invoice.AccountNr,
                Products = invoice.Products,
                Date = new DateTime(),
                Number = invoice.Number
            };

            dbservice.AddInvoice(Invoice);

            return RedirectToAction("Orders");
        }

        [Route("Receipt")]
        public IActionResult Receipt(Order order)
        {
            var document = new ReceiptDto()
            {
                Worker = new Worker(),
                Products = new List<Product>(order.Products),
                Price = 34
            };
            return View(document);
        }

        [Route("SaveReceipt")]
        public IActionResult SaveReceipt(ReceiptDto receipt)
        {
            var Invoice = new Receipt()
            {               
                Price = receipt.Price,               
                Products = receipt.Products,
                Date = new DateTime(),
                Number = receipt.Number
            };

            dbservice.AddReceipt(Invoice);

            return RedirectToAction("Orders");
        }
    }
}
