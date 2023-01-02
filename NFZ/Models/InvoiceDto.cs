namespace NFZ.Models
{
    public class InvoiceDto : DocumentDto
    {
        public DateTime PaymentDate;

        public string ClientName;

        public int NIP;

        public int AccountNr;
    }
}
