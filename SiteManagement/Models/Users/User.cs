using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Payments;

namespace SiteManagement.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string SurName { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public int ApartmentNumber { get; set; } 
        public Apartment Apartments { get; set; } 
        public UserRole UserRole { get; set; } = UserRole.User;
        public Payment? Payments { get; set; }
    }
}
