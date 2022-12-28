namespace NFZ.Entities
{
    public class Document
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
        
        public virtual List<Worker> Workers { get; set; }

        public virtual List<Product> Products { get; set; }

        public float Price { get; set; }

        public DateOnly Date { get; set; }
    }
}
