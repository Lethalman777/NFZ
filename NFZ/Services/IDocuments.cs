using NFZ.Entities;
using NFZ.Models;

namespace NFZ.Services
{
    public interface IDocuments
    {
        DocumentDto GetTemplate(Order order);
        List<Document> GetDocuments(List<string> types);
    }
}