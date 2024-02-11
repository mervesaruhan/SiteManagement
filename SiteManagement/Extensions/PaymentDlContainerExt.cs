using SiteManagement.Models.AdminServices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.Users;

namespace SiteManagement.Extensions
{
    public static class PaymentDlContainerExt
    {
        public static void AddPaymentDlContainer(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

        }
    }
}
