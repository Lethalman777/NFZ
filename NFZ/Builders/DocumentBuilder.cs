using NFZ.Entities;
using NFZ.Iterators;
using NFZ.Models;

namespace NFZ.Builders
{
    public abstract class DocumentBuilder
    {
        public abstract void BuildTemplate();
        public abstract DocumentDto GetTemplate();
    }
}
