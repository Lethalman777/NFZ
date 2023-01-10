using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;

namespace NFZ.Models
{
    public abstract class DocumentDto
    {
        public int Number { get; set; }

        public Worker Worker { get; set; }

        public List<Product> Products { get; set; }

        public List<SelectListItem> selectLists { get; set; }

        public SelectListItem selectedItem { get; set; }

        public decimal Price { get; set; }
    }
}
