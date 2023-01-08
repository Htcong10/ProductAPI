using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string imageUrl { get; set; }
        public int CategoryId { get; set; }

    }
}


