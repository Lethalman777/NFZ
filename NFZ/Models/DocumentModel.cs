using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;

namespace NFZ.Models
{
    public class DocumentModel
    {
        public int Number { get; set; }

        public List<Product> Products { get; set; }

        public List<int> ProductIds { get; set; }

        public List<float> ProductCounts { get; set; }

        public List<SelectListItem> selectLists { get; set; }

        public string SelectName { get; set; } = "1";

        public decimal Price { get; set; }

        public DateTime PaymentDate { get; set; }
        
        public DateTime Date { get; set; }

        public string ClientName { get; set; }

        public int NIP { get; set; }

        public int AccountNr { get; set; }

        public bool isInvoice { get; set; }

        public bool isSelect { get; set; }
    }
}
