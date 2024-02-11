using Microsoft.AspNetCore.Identity;

namespace TokenAuth.API.MODELS
{
    public class AppUser:IdentityUser<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string SurName { get; set; } = default!;
        public string Email { get; set; }
        public string TcNo { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Role { get; set; } // Kullanıcının rolü (Admin/User)
    }
}
