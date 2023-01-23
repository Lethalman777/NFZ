namespace NFZ.Entities
{
    public class Document
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string ClientName { get; set; }

        public int WorkerId { get; set; }

        public Worker Worker { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }
    }
}
