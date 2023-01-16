using Microsoft.AspNetCore.Mvc.Rendering;
using NFZ.Entities;

namespace NFZ.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = "";

        public bool isInvoke { get; set; }

        public List<Product> Products { get; set; }

        public List<int> productId { get; set; } = new List<int>();

        public List<SelectListItem> ProductSelectList { get; set; }

        public string selectId { get; set; } = "1";

        public bool isSelect { get; set; }

        public int Price { get; set; }
    }
}
