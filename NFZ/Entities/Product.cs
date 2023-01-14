namespace NFZ.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool isCountable { get; set; }

        public float Count { get; set; }

        public int Vat { get; set; }

        public List<ReceiptProduct> receiptProducts { get; set; }

        public List<InvoiceProduct> invoiceProducts { get; set; }
    }
}
