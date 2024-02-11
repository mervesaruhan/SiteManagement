namespace SiteManagement.Models.Users.DTO
{
    public class RegisterUserDtoRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
