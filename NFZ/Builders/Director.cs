using NFZ.Models;

namespace NFZ.Builders
{
    public class Director
    {
        public void Construct(DocumentBuilder builder)
        {           
            builder.BuildTemplate();
            builder.SetProducts();
            builder.SetClientInfo();
            builder.SetCompanyInfo();
            builder.SetOrderInfo();
        }

        public void Construct(PerfectDocumentBuilder builder)
        {
            builder.BuildDocument();
        }
    }
}
