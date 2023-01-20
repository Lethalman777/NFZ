using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public abstract class DocumentBuilder  //Abstrakcyjna klasa po której dziedziczą BuildInvoice i BuildReceipt
    {                                           
        public abstract void BuildTemplate();
        public abstract DocumentModel GetTemplate();
        public abstract void SetProducts();
        public abstract void SetCompanyInfo();
        public abstract void SetClientInfo();
        public abstract void SetOrderInfo();
    }
}
