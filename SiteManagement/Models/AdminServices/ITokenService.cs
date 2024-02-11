using SiteManagement.Models.Users;

namespace SiteManagement.Models.AdminServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
