using NFZ.Entities;
using NFZ.Iterators;

namespace NFZ.Models
{
    public class CarouselInvoiceModel
    {
        public Iterator iterator { get; set; }

        public Invoice invoice { get; set; }
    }
}
