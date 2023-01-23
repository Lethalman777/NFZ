using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Builders;
using NFZ.COResponsibility;
using NFZ.Decorators;
using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;
using NFZ.Services;

namespace NFZ.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDatabaseService dbservice;
        private readonly IDocuments documents;
        private readonly IPackaging packaging;
        private Iterator iterator;

        public DocumentController(IDatabaseService dbservice, IDocuments documents, IPackaging packaging, IIterator iterator)   //Konstruktor zawierający wszystkie servicy
        {
            this.dbservice = dbservice;
            this.documents = documents;
            this.packaging = packaging;
            //this.iterator = iterator;
            this.iterator = new Iterator(dbservice);
        }

        public IActionResult AddOrder()     //Dodanie zamówienia
        {
            var order = new OrderModel()
            {
                productId = new List<int>() { 1 },
                Products = new List<Product>() { dbservice.GetProduct(1) },
                isInvoke = true,
                Price = 0,
                ClientName = "",
                isSelect = false,
                Country = "",
                package = ""
            };
            return View("AddOrder", order);
        }

        [Route("SaveOrder")]
        public IActionResult SaveOrder(OrderModel model)    //Zapisanie zamówienia
        {
            var order = new Order()
            {
                Products = new List<OrderProduct>(),
                isInvoke = model.isInvoke,
                ClientName = model.ClientName,
                Date = DateTime.Now,
                Package = model.package,
                Department = model.Country
            };
            
            var r = new Random();
            foreach (var id in model.productId)
            {
                if (model.productId.IndexOf(id) == 0)
                    continue;
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
        public IActionResult Documents()    //Zwraca listę dokumentów
        {
            var list = dbservice.GetMixedDocuments();

            return View(list);
        }

        [Route("InvoiceDetail")]
        public IActionResult InvoiceDetail(int number)  //Zwraca konkretą faktórę o numerze podanym w parametrze
        {
            var model = dbservice.GetDocument(number, true);

            return View(model);
        }

        [Route("ReceiptDetail")]
        public IActionResult ReceiptDetail(int number)  //Zwraca paragon o numerze podanym w parametrze
        {
            var model = dbservice.GetDocument(number, false);

            return View(model);
        }

        [Route("Orders")]
        public IActionResult Orders()   //Zwraca listę zamówień
        {
            //var orders = new List<OrderModel>()
            //{
            //    new OrderModel()
            //    {
            //        Id = 1,
            //        ClientName = "Dawid",
            //        Products = new List<Product>()
            //        {
            //            dbservice.GetProduct(1),
            //            dbservice.GetProduct(2)
            //        },
            //        isInvoke = true,
            //        Packaging = new PalleteDecorator(packaging),
            //        Date = DateTime.Now
            //    },
            //    new OrderModel()
            //    {
            //        Id = 2,
            //        ClientName = "Łukasz",
            //        Products = new List<Product>()
            //        {
            //            dbservice.GetProduct(1),
            //            dbservice.GetProduct(2)
            //        },
            //        isInvoke = false,
            //        Packaging = new PalleteDecorator(packaging),
            //        Date = DateTime.Now
            //    },
            //    new OrderModel()
            //    {
            //        Id = 3,
            //        ClientName = "Janusz",
            //        Products = new List<Product>()
            //        {
            //            dbservice.GetProduct(1),
            //            dbservice.GetProduct(2),
            //            dbservice.GetProduct(3)
            //        },
            //        isInvoke = true,
            //        Packaging = new EnvelopeDecorator(packaging),
            //        Date = DateTime.Now
            //    },
            //    new OrderModel()
            //    {
            //        Id = 4,
            //        ClientName = "Aureliusz",
            //        Products = new List<Product>()
            //        {
            //            dbservice.GetProduct(1),
            //            dbservice.GetProduct(2),
            //            dbservice.GetProduct(3),
            //            dbservice.GetProduct(4)
            //        },
            //        isInvoke = false,
            //        Packaging = new CardboardDecorator(packaging),
            //        Date = DateTime.Now
            //    },
            //    new OrderModel()
            //    {
            //        Id = 5,
            //        ClientName = "Edyta",
            //        Products = new List<Product>()
            //        {
            //            dbservice.GetProduct(1),
            //            dbservice.GetProduct(3)
            //        },
            //        isInvoke = false,
            //        Packaging = new PalleteDecorator(packaging),
            //        Date = DateTime.Now
            //    }
            //};

            var list = dbservice.GetOrders();
            var orders = new List<OrderModel>();
            foreach (var id in list)
            {
                orders.Add(new OrderModel()
                {
                    Id = id.Id,
                    ClientName = id.ClientName,
                    isInvoke = id.isInvoke,
                    Products = new List<Product>(),
                    Date = DateTime.Now,
                    Country = id.Department,
                    package = id.Package
                });
                if(id.Package == "Karton")
                    orders[orders.Count - 1].Packaging = new CardboardDecorator(packaging);
                else if(id.Package == "Paleta")
                    orders[orders.Count - 1].Packaging = new PalleteDecorator(packaging);
                else
                    orders[orders.Count - 1].Packaging = new EnvelopeDecorator(packaging);
                foreach (var product in id.Products)
                {
                    orders[orders.Count - 1].Products.Add(product.ProductMany);
                }
            }
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

            return View(orders);
        }

        [Route("Invoice")]
        public IActionResult Invoice(OrderModel order)  //Zwraca Fakturę
        {
            order.Products = new List<Product>();
            foreach (var product in order.productId)
            {
                order.Products.Add(dbservice.GetProduct(product));
            }
            order.isInvoke = true;
            var document = documents.GetTemplate(order);
            document.isInvoice = true;

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var product in dbservice.GetProducts())
            {
                list.Add(new SelectListItem()
                {
                    Text = product.Name,
                    Value = product.Id.ToString()
                });
            }

            document.selectLists = list;

            return View(document);
        }

        [Route("SaveInvoice")]
        public IActionResult SaveInvoice(DocumentModel invoice) //Zapisanie faktury
        {
            documents.SaveDocument(invoice);

            return RedirectToAction("Orders");
        }

        [Route("Receipt")]
        public IActionResult Receipt(OrderModel order)  //
        {
            order.Products = new List<Product>();
            foreach (var product in order.productId)
            {
                order.Products.Add(dbservice.GetProduct(product));
            }
            order.isInvoke = false;
            var document = documents.GetTemplate(order);
            document.isInvoice = false;

            return View(document);
        }

        [Route("SaveReceipt")]
        public IActionResult SaveReceipt(DocumentModel receipt) //Zapisanie paragonu
        {
            documents.SaveDocument(receipt);

            return RedirectToAction("Orders");
        }

        public IActionResult ShowDocumentList(DocumentModel model)  //Zwraca listę wszystkich dokumentów
        {
            model.isSelect = true;
            //model.SelectName = "";

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

        public IActionResult ShowOrderList(OrderModel model)    //Wyświetlenie listy zamówień
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
            foreach (var id in model.ProductIds)
            {
                model.Products.Add(dbservice.GetProduct(id));
            }

            var product = dbservice.GetProductName(model.SelectName);
            model.Products.Add(product);
            model.ProductIds.Add(product.Id);
            var r = new Random();
            model.ProductCounts.Add((float)r.Next(1, (int)product.Count));

            model.isSelect = false;
            //model.SelectName = "";

            return View("Invoice", model);
        }

        public IActionResult AddProductFromListOrder(OrderModel model)
        {
            model.Products = new List<Product>();
            foreach (var id in model.productId)
            {
                model.Products.Add(dbservice.GetProduct(id));
            }

            var product = dbservice.GetProductName(model.selectId);
            model.Products.Add(product);

            model.productId.Add(product.Id);

            model.isSelect = false;
            model.selectId = "";

            return View("AddOrder", model);
        }

        public IActionResult DeleteProduct(DocumentModel model, int id) //Usunięcie produktu
        {
            var product = model.Products.FirstOrDefault(x => x.Id == id);
            model.Products.Remove(product);
            return View("Invoice", model);
        }

        public IActionResult NextInvoice(int number)
        {
            var model = new CarouselInvoiceModel();
            model.iterator = new Iterator(dbservice);
            model.iterator.isInvoice = true;
            model.iterator.currentNumber = number;
            if (!model.iterator.isDone())
                model.invoice = (Invoice)model.iterator.Next();
            model.invoice = (Invoice)model.iterator.CurrentDocument();
            return View("CarouselInvoice", model);
        }

        public IActionResult StartInvoice()
        {
            var model = new CarouselInvoiceModel();
            model.iterator = new Iterator(dbservice);
            model.iterator.isInvoice = true;
            model.invoice = (Invoice)model.iterator.First();

            return View("CarouselInvoice", model);
        }

        public IActionResult NextReceipt(int number)
        {
            var model = new CarouselReceiptModel();
            model.iterator = new Iterator(dbservice);
            model.iterator.isInvoice = false;
            model.iterator.currentNumber = number;
            if (!model.iterator.isDone())
                model.receipt = (Receipt)model.iterator.Next();
            model.receipt = (Receipt)model.iterator.CurrentDocument();
            return View("CarouselReceipt", model);
        }

        public IActionResult StartReceipt()
        {
            var model = new CarouselReceiptModel();
            model.iterator = new Iterator(dbservice);
            model.iterator.isInvoice = false;
            model.receipt = (Receipt)model.iterator.First();

            return View("CarouselReceipt", model);
        }

        public IActionResult Login()
        {
            var model = new WorkerModel();

            return View("Login", model);
        }

        public IActionResult LoginConfirm(WorkerModel model)
        {
            var handler = new PasswordHandler(dbservice).SetNextHandler(new LoginHandler(dbservice));
            var authService = new AuthService(handler);

            if (authService.LogIn(model.Login, model.Password))
            {
                HttpContext.Session.SetString("isLoged", "true");
                return RedirectToAction("Orders");
            }
            return View("Login", new WorkerModel());
        }

        public IActionResult Register()
        {
            var model = new RegisterModel();

            return View("Registration", model);
        }

        public IActionResult RegisterConfirm(RegisterModel model)
        {
            //var handler = new LastnameHandler()
            //    .SetNextHandler(new FirstnameHandler()
            //    .SetNextHandler(new PasswordRegisterHandler()
            //    .SetNextHandler(new LoginRegisterHandler(dbservice))));
            var handler = new LoginRegisterHandler(dbservice);
            handler.SetNextHandler(new PasswordRegisterHandler())
                .SetNextHandler(new FirstnameHandler())
                .SetNextHandler(new LastnameHandler());
            var authService = new AuthService(handler);

            if (authService.Register(model.Login, model.Password, model.ConfirmPassword, model.Name, model.SurName))
            {
                var worker = new Worker()
                {
                    Name = model.Name,
                    Surname = model.SurName,
                    Login = model.Login,
                    Password = model.Password
                };
                dbservice.AddWorker(worker);
                return RedirectToAction("Login");
            }
            return View("Registration", new RegisterModel());
        }
        public IActionResult AddProduct()
        {
            var product = new ProductModel();

            return View("AddProduct", product);
        }
        public IActionResult AddProductConfirm(ProductModel model)
        {
            var handler = new Product();
            handler.Name = model.Name;
            handler.Price = model.Price;
            handler.Count = model.Count;
            handler.Vat = model.Vat;
            dbservice.AddProduct(handler);
            return View("AddProduct", new ProductModel());
        }
        public IActionResult Products(ProductModel model)
        {

            List<Product> products = new List<Product>();
            foreach (var product in dbservice.GetProducts())
            {
                products.Add(new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Count = product.Count,
                    Vat = product.Vat,

                });
            }

            return View("Products", products);
        }
    }
}
