using SiteManagement.Models.AparmentInfos;

namespace SiteManagement.Models.Users.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public int ApartmentNumber { get; set; } 
        public Apartment Apartments { get; set; } 
        public UserRole UserRole { get; set; } = default!;

    }
}
