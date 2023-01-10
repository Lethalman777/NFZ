using NFZ.Entities;

namespace NFZ.Decorators
{
    public interface IDocumentDecorator
    {
        public abstract List<Document> GetDocumentsList(List<Document> documents);
    }
}