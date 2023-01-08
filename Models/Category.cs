using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
