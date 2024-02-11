namespace SiteManagement.Models.Users.Requests
{
    public class PayBillRequest
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
    }

}
