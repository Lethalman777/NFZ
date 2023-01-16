namespace NFZ.Entities
{
    public class InvoiceProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int InvoiceId { get; set; }

        public Invoice InvoiceMany { get; set; }

        public Product ProductMany { get; set; }

        public float ProductCount { get; set; }
    }
}
