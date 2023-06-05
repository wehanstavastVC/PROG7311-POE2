using Microsoft.AspNetCore.Identity;

namespace FarmerCentral2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Product>? Products { get; set; }
    }
}
