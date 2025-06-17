using Microsoft.AspNetCore.Identity;

namespace TranQuangKhai_2280601379_LTW.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
}
