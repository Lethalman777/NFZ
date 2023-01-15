namespace NFZ.Entities
{
    public class Document
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int WorkerId { get; set; }

        public Worker Worker { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
