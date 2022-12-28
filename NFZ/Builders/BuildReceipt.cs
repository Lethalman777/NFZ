using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Builders
{
    public class BuildReceipt : Builder
    {
        public ReceiptDto document;

        public BuildReceipt(ReceiptDto document)
        {
            this.document = document;
        }

        public override Document BuildDocument()
        {
            throw new NotImplementedException();
            var receipt = new Receipt()
            {
                Worker = document.Worker,
                Products = new List<Product>(document.Products),
                Price = document.Price
            };

            return receipt;
        }
    }
}
