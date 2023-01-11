using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;

namespace NFZ.Models
{
    public class DocumentModel
    {
        public int Number { get; set; }

        public Worker Worker { get; set; }

        public List<Product> Products { get; set; }

        public List<SelectListItem> selectLists { get; set; }

        public SelectListItem selectedItem { get; set; }

        public decimal Price { get; set; }

        public DateTime PaymentDate { get; set; }

        public string ClientName { get; set; }

        public int NIP { get; set; }

        public int AccountNr { get; set; }

        public bool isInvoice { get; set; }
    }
}
