using NFZ.Entities;
using NFZ.Iterators;

namespace NFZ.Models
{
    public class CarouselReceiptModel
    {
        public Iterator iterator { get; set; }

        public Receipt receipt { get; set; }
    }
}
