using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;

namespace NFZ.Models
{
    public class OrderModel
    {
        public string ClientName { get; set; }

        public bool isInvoke { get; set; }

        public List<Product> Products { get; set; }

        public List<int> productId { get; set; }

        public List<SelectListItem> ProductSelectList { get; set; }

        public bool isSelect { get; set; }

        public int Price { get; set; }
    }
}
