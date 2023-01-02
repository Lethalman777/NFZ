using Microsoft.AspNetCore.Mvc;
using NFZ.Entities;
using NFZ.Services;

namespace NFZ.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DatabaseService dbservice;

        public DocumentController(DatabaseService dbservice)
        {
            this.dbservice = dbservice;
        }

        [Route("Orders")]
        public IActionResult GetOrders()
        {
            //var orders = dbservice.GetOrders().ToList();
            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    ClientName = "kola",
                    Products = new List<Product>(),
                    isInvoke = true
                }
            };
            return View(orders);
        }

        [Route("Invoice")]
        public IActionResult GetInvoice()
        {
            return View();
        }

        [Route("Receipt")]
        public IActionResult GetReceipt()
        {
            return View();
        }
    }
}
