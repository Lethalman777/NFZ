namespace NFZ.Entities
{
    public class Receipt : Document
    {
        public List<ReceiptProduct> Products { get; set; }
    }
}
