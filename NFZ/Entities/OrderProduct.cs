namespace NFZ.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public Order OrderMany { get; set; }

        public Product ProductMany { get; set; }

        public float ProductCount { get; set; }
    }
}
