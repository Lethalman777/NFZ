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
            var orders = new List<OrderModel>()
            {
                new OrderModel()
                {
                    ClientName = "kola",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Id = dbservice.GetProduct(1).Id,
                            Name = dbservice.GetProduct(1).Name,
                            Price = dbservice.GetProduct(1).Price,
                            isCountable = dbservice.GetProduct(1).isCountable,
                            Count = dbservice.GetProduct(1).Count,
                            Vat = dbservice.GetProduct(1).Vat
                        }
                    },
                    isInvoke = true,
                }
            };
            foreach (var order in orders)
            {
                order.productId = new List<int>();
                foreach(var product in order.Products)
                {
                    order.productId.Add(product.Id);
                }
            }
            return View(orders);
        }

        [Route("Invoice")]
        public IActionResult Invoice(OrderModel order)
        {
            order.Products = new List<Product>();
            foreach(var product in order.productId)
            {
                order.Products.Add(dbservice.GetProduct(product));
            }
            var document = documents.GetTemplate(order);

            return View(document);
        }

        [Route("SaveInvoice")]
        public IActionResult SaveInvoice(DocumentModel invoice)
        {
            documents.SaveDocument(invoice);

            return RedirectToAction("Orders");
        }

        [Route("Receipt")]
        public IActionResult Receipt(Order order)
        {
            var document = new DocumentModel()
            {
                Products = new List<Product>(order.Products),
                Price = 34
            };
            return View(document);
        }

        [Route("SaveReceipt")]
        public IActionResult SaveReceipt(DocumentModel receipt)
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
