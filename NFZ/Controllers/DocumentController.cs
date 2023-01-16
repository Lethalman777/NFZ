﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Builders;
using NFZ.Decorators;
using NFZ.Entities;
using NFZ.Models;
using NFZ.Services;

namespace NFZ.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDatabaseService dbservice;
        private readonly IDocuments documents;
        private readonly IPackaging packaging;

        public DocumentController(IDatabaseService dbservice, IDocuments documents, IPackaging packaging)
        {
            this.dbservice = dbservice;
            this.documents = documents;
            this.packaging = packaging;
        }

        [Route("AddToOrder")]
        public IActionResult AddOrder()
        {
            var order = new OrderModel()
            {
                productId = new List<int>(),
                isInvoke = true,
                Price = 0,
                ClientName = "ios",
                isSelect = false
            };
            return View(order);
        }

        [Route("SaveOrder")]
        public IActionResult SaveOrder(OrderModel model)
        {
            var order = new Order()
            {
                Products = new List<OrderProduct>(),
                isInvoke = model.isInvoke,
                ClientName = model.ClientName
            };

            foreach (var id in model.productId)
            {
                order.Products.Add(new OrderProduct()
                {
                    OrderMany = order,
                    ProductMany = dbservice.GetProduct(id),
                    ProductCount = 10
                });
            }

            dbservice.AddOrder(order);
            return RedirectToAction("Orders");
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
                    Id = 1,
                    ClientName = "Dawid",
                    Products = new List<Product>()
                    {
                        dbservice.GetProduct(1),
                        dbservice.GetProduct(2)
                    },
                    isInvoke = true,
                    Packaging = new PalleteDecorator(packaging),
                    Date = DateTime.Now
                },
                new OrderModel()
                {
                    Id = 2,
                    ClientName = "Łukasz",
                    Products = new List<Product>()
                    {
                        dbservice.GetProduct(1),
                        dbservice.GetProduct(2)
                    },
                    isInvoke = false,
                    Packaging = new PalleteDecorator(packaging),
                    Date = DateTime.Now
                },
                new OrderModel()
                {
                    Id = 3,
                    ClientName = "Janusz",
                    Products = new List<Product>()
                    {
                        dbservice.GetProduct(1),
                        dbservice.GetProduct(2),
                        dbservice.GetProduct(3)
                    },
                    isInvoke = true,
                    Packaging = new EnvelopeDecorator(packaging),
                    Date = DateTime.Now
                },
                new OrderModel()
                {
                    Id = 4,
                    ClientName = "Aureliusz",
                    Products = new List<Product>()
                    {
                        dbservice.GetProduct(1),
                        dbservice.GetProduct(2),
                        dbservice.GetProduct(3),
                        dbservice.GetProduct(4)
                    },
                    isInvoke = false,
                    Packaging = new CardboardDecorator(packaging),
                    Date = DateTime.Now
                }
            };
            foreach (var order in orders)
            {
                order.Price = 0;
                order.productId = new List<int>();
                foreach (var product in order.Products)
                {
                    order.productId.Add(product.Id);
                    order.Price += product.Price;
                }
            }

            //var r = dbservice.GetOrders();
            //List<OrderModel> list = new List<OrderModel>();

            //foreach (var order in r)
            //{
            //    var q = new OrderModel()
            //    {
            //        ClientName = order.ClientName,
            //        isInvoke = order.isInvoke,
            //        Products = dbservice.GetProductOrder(order.Id)
            //    };
            //    list.Add(q);
            //    q.productId = new List<int>();
            //    foreach (var product in q.Products)
            //    {
            //        q.productId.Add(product.Id);
            //    }
            //}

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
            model.SelectName = "";

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

            var product = dbservice.GetProduct(int.Parse(model.SelectName));
            model.Products.Add(product);
            model.ProductIds.Add(product.Id);

            model.isSelect = false;
            model.SelectName = "";

            return View("Invoice", model);
        }

        public IActionResult AddProductFromListOrder(OrderModel model)
        {
            model.Products = new List<Product>();
            foreach (var id in model.productId)
            {
                model.Products.Add(dbservice.GetProduct(id));
            }

            model.Products.Add(dbservice.GetProduct(int.Parse(model.selectId)));

            var product = dbservice.GetProduct(int.Parse(model.selectId));
            model.Products.Add(product);
            model.productId.Add(product.Id);

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
