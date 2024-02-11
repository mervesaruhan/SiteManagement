using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Users;

namespace SiteManagement.Models.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public int UserId { get; set; }
        public virtual User Users { get; set; }

    }
}
