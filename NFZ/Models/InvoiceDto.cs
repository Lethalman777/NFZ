namespace NFZ.Models
{
    public class InvoiceDto : DocumentDto
    {
        public DateOnly PaymentDate;

        public string ClientName;

        public int NIP;

        public int AccountNr;
    }
}
