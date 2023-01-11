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
            Worker worker = new Worker()
            {
                Id = 1,
                Name = databaseService.GetWorker(1).Name,
                Surname = databaseService.GetWorker(1).Surname,
                Login = databaseService.GetWorker(1).Login,
                Password = databaseService.GetWorker(1).Password
            };
            if (model.isInvoice)
            {
                builder = new PerfectInvoiceBuilder(model, worker);
            }
            else
            {
                builder = new PerfectReceiptBuilder(model, worker);
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

        public List<Document> GetDocuments(List<string> types)
        {
            DocumentDecorator decorator;
            documents = databaseService.GetDocuments(true).ToList();
            foreach(var item in types)
            {
                switch (item)
                {
                    case "Price":
                        decorator = new DocumentDecoratorPrice();
                        documents = decorator.GetDocumentsList(documents);
                        break;
                    case "Date":
                        decorator = new DocumentDecoratorDate();
                        documents = decorator.GetDocumentsList(documents);
                        break;
                    case "ClientName":
                        decorator = new DocumentDecoratorClientName();
                        documents = decorator.GetDocumentsList(documents);
                        break;
                }
            }
            return documents;
        }
    }
}
