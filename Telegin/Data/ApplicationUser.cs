using Microsoft.AspNetCore.Identity;

namespace Telegin.UI.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string? NickName { get; set; }
        public string? PassWord { get; set; }
    }
}
