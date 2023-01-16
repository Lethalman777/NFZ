using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Services
{
    public interface IDocuments
    {
        DocumentModel GetTemplate(OrderModel order);
        void SaveDocument(DocumentModel document);

        //Funkcja wyłączona z użytku
        //List<Document> GetDocuments(List<string> types);
    }
}