using NFZ.Entities;

namespace NFZ.Builders
{
    public abstract class PerfectDocumentBuilder
    {
        public abstract void BuildDocument();
        public abstract Document GetDocument();
    }
}
