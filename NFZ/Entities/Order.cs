namespace NFZ.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public bool isInvoke { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
