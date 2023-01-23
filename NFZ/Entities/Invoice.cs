using System.ComponentModel.DataAnnotations;

namespace NFZ.Entities
{
    public class Invoice : Document
    {
        public DateTime PaymentDate { get; set; }

        public string NIP { get; set; }

        public string AccountNr { get; set; }

        public List<InvoiceProduct> Products { get; set; }
    }
}
