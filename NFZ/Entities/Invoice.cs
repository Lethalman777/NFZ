using System.ComponentModel.DataAnnotations;

namespace NFZ.Entities
{
    public class Invoice : Document
    {
        public DateTime PaymentDate { get; set; }

        public string ClientName { get; set; }

        public int NIP { get; set; }

        public int AccountNr { get; set; }

        public List<InvoiceProduct> Products { get; set; }
    }
}
