using Microsoft.AspNetCore.Identity;

namespace ProductAPI.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
        public string ChucNangDefault { get; set; }
    }
}
