using NFZ.Entities;

namespace NFZ.Decorators
{
    public abstract class DocumentDecorator : IDocumentDecorator
    {
        public List<Document> documents;

        public List<Document> GetDocumentsList(List<Document> documents)
        {
            this.documents = documents;
            return documents;
        }

        protected abstract void SortDocument();
    }
}
