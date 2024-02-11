using Microsoft.AspNetCore.Authorization;
using SiteManagement.MiddleWare;
using SiteManagement.Models.AdminServices;
using SiteManagement.Models.Users;

namespace SiteManagement.Extensions
{
    public static class UserDlContainerExt
    {
        public static void AddUserDlContainer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<AdminInitializer>();

            //services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<ITokenService>(new TokenService("yourSecretKey", "SiteMangement", "Admin"));
            


        }
    }
}
