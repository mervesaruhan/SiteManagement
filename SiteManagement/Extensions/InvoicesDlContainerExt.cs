using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;

namespace SiteManagement.Extensions
{
    public static class InvoicesDlContainerExt
    {
        public static void AddInvoicesDlContainer(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<MonthlyExpenses>();

        }

    }
}
