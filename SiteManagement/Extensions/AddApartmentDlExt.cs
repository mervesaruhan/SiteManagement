using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Invoices;

namespace SiteManagement.Extensions
{
    public static class AddApartmentDlExt
    {
        public static void AddApartmentsDlContainer(this IServiceCollection services)
        {
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentService, ApartmentService>();
            

        }

    }
}
