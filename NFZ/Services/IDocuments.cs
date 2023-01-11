using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Services
{
    public interface IDocuments
    {
        DocumentModel GetTemplate(OrderModel order);
        void SaveDocument(DocumentModel document);
        List<Document> GetDocuments(List<string> types);
    }
}