namespace NFZ.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool isCountable { get; set; }

        public float Count { get; set; }

        public int Vat { get; set; }
    }
}
