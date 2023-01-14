namespace NFZ.Entities
{
    public class ReceiptProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ReceiptId { get; set; }

        public Receipt ReceiptMany { get; set; }

        public Product ProductMany { get; set; }
    }
}
