using NFZ.Entities;

namespace NFZ.Decorators
{
    public class DocumentDecoratorPrice : DocumentDecorator
    {
        public List<Document> GetDocumentsList(List<Document> documents)
        {
            this.documents = documents;
            SortDocument();

            return documents;
        }

        protected override void SortDocument()
        {
            for (int i = 0; i < documents.Count - 1; i++)
            {
                for (int j = 0; j < documents.Count - 1 - i; j++)
                {
                    if (documents[j].Price > documents[j + 1].Price)
                    {
                        var item = documents[j + 1];
                        documents[j + 1] = documents[j];
                        documents[j] = item;
                    }
                }
            }
        }
    }
}
