using NFZ.Builders;
using NFZ.Decorators;
using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Services
{
    public class Documents : IDocuments
    {
        List<Document> documents;
        IDatabaseService databaseService;
        public Documents(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public DocumentModel GetTemplate(OrderModel order)
        {
           var iterator = new Iterator(databaseService);
            
            DocumentBuilder builder = null;
            if (order.isInvoke)
            {
                builder = new BuildInvoice(order, iterator);
            }
            else
            {
                builder = new BuildReceipt(order, iterator);
            }


            Director director = new Director();
            director.Construct(builder);
            var documentDto = builder.GetTemplate();
            return documentDto;
        }

        public void SaveDocument(DocumentModel model)
        {
            PerfectDocumentBuilder builder;
           
            if (model.isInvoice)
            {
                builder = new PerfectInvoiceBuilder(model, new Iterator(databaseService));
            }
            else
            {
                builder = new PerfectReceiptBuilder(model, new Iterator(databaseService));
            }
            Director director = new Director();
            director.Construct(builder);

            if (model.isInvoice)
            {
                var document = (Invoice)builder.GetDocument();
                databaseService.AddInvoice(document);
            }
            else
            {
                var document = (Receipt)builder.GetDocument();
                databaseService.AddReceipt(document);
            }
        }

        //Funkcja wyłączona z użytku
        //
        //public List<Document> GetDocuments(List<string> types)
        //{
        //    return documents;
        //}
    }
}
