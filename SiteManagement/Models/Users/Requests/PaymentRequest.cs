using SiteManagement.Models.Payments;

namespace SiteManagement.Models.Users.Requests
{
    public class PaymentRequest
    {
        public int BillId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
