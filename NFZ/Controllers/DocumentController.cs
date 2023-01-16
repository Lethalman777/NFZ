using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("AddToOrder")]
        public IActionResult AddOrder()
        {
            var order = new OrderModel();
            return View(order);
        }

        [Route("Documents")] 
        public IActionResult Documents()
        {
            var list = dbservice.GetMixedDocuments();           
            
            return View(list);
        }

        [Route("InvoiceDetail")]
        public IActionResult InvoiceDetail(int number)
        {
            var model = dbservice.GetDocument(number, true);

            return View(model);
        }

        [Route("ReceiptDetail")]
        public IActionResult ReceiptDetail(int number)
        {
            var model = dbservice.GetDocument(number, false);

            return View(model);
        }

        [Route("Orders")]
        public IActionResult Orders()
        {
            var orders = new List<OrderModel>()
            {
                new OrderModel()
                {
                    ClientName = "kola",
                    Products = new List<Product>()
                    {
                        dbservice.GetProduct(1),
                        dbservice.GetProduct(2)
                    },
                    isInvoke = true,
                }
            };
            foreach (var order in orders)
            {
                order.productId = new List<int>();
                foreach (var product in order.Products)
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
            document.isInvoice = true;

            return View(document);
        }

        [Route("SaveInvoice")]
        public IActionResult SaveInvoice(DocumentModel invoice)
        {
            documents.SaveDocument(invoice);
          
            return RedirectToAction("Orders");
        }

        [Route("Receipt")]
        public IActionResult Receipt(OrderModel order)
        {
            order.Products = new List<Product>();
            foreach (var product in order.productId)
            {
                order.Products.Add(dbservice.GetProduct(product));
            }
            var document = documents.GetTemplate(order);
            document.isInvoice = false;

            return View(document);
        }

        [Route("SaveReceipt")]
        public IActionResult SaveReceipt(DocumentModel receipt)
        {
            documents.SaveDocument(receipt);

            return RedirectToAction("Orders");
        }

        public IActionResult ShowDocumentList(DocumentModel model)
        {     
            model.isSelect = true;
            model.selectId = "";

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var product in dbservice.GetProducts())
            {
                list.Add(new SelectListItem()
                {
                    Text = product.Name,
                    Value = product.Id.ToString()
                });
            }

            model.selectLists = list;

            return View("Invoice", model);
        }

        public IActionResult ShowOrderList(OrderModel model)
        {
            model.isSelect = true;
            model.selectId = "";

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var product in dbservice.GetProducts())
            {
                list.Add(new SelectListItem()
                {
                    Text = product.Name,
                    Value = product.Id.ToString()
                });
            }

            model.ProductSelectList = list;

            return View("AddOrder", model);
        }

        public IActionResult AddProductFromListDocument(DocumentModel model)
        {
            model.Products = new List<Product>();
            foreach(var id in model.ProductIds)
            {
                model.Products.Add(dbservice.GetProduct(id));
            }
            model.Products.Add(dbservice.GetProduct(int.Parse(model.selectId)));

            model.isSelect = false;
            model.selectId = "";

            return View("Invoice", model);
        }

        public IActionResult AddProductFromListOrder(OrderModel model)
        {
            model.Products.Add(new Product()
            {
                Id = dbservice.GetProduct(int.Parse(model.selectId)).Id,
                Name = dbservice.GetProduct(int.Parse(model.selectId)).Name,
                Price = dbservice.GetProduct(int.Parse(model.selectId)).Price,
                isCountable = dbservice.GetProduct(int.Parse(model.selectId)).isCountable,
                Vat = dbservice.GetProduct(int.Parse(model.selectId)).Vat,
                Count = dbservice.GetProduct(int.Parse(model.selectId)).Count
            });

            model.isSelect = false;
            model.selectId = "";

            return View("Order", model);
        }

        public IActionResult DeleteProduct(DocumentModel model, int id)
        {
            var product = model.Products.FirstOrDefault(x => x.Id == id);
            model.Products.Remove(product);
            return View("Invoice", model);
        }
    }
}
