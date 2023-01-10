using NFZ.Entities;

namespace NFZ.Iterators
{
    public interface IIterator
    {
        Document CurrentDocument();
        Document First();
        bool isDone();
        void Next();
    }
}