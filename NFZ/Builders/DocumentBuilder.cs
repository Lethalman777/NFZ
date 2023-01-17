using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public abstract class DocumentBuilder  //Abstrakcyjna klasa po której dziedziczą BuildInvoice i BuildReceipt
    {                                           
        public abstract void BuildTemplate();
        public abstract DocumentModel GetTemplate();
    }
}
