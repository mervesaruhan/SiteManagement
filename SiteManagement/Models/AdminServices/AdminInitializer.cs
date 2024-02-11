using SiteManagement.Models.Users;
using SiteManagement.Models;
using SiteManagement.Models.AdminServices;

public class AdminInitializer
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AdminInitializer(AppDbContext context, IUserRepository userRepository, ITokenService tokenService)
    {
        _context = context;
        _userRepository = userRepository;
        _tokenService = tokenService;
       
    }

    public void InitializeAdmin()
    {
        var adminUser = _context.Users.FirstOrDefault(u => u.UserRole ==  UserRole.Admin);

        if (adminUser == null)
        {
            var newAdmin = new User
            {
                Name = "Admin",
                SurName = "AdminSurname",
                Email ="admin@outlook.com",
                TcNo = "11111111111",
                PhoneNumber = "055555555555",
                UserRole = UserRole.Admin

            };

            _userRepository.RegisterUser(newAdmin); 

            
            var token = _tokenService.GenerateToken(newAdmin);



            Console.WriteLine("Admin Token: " + token);
        }
    }
}
