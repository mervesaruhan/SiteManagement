using Microsoft.EntityFrameworkCore;

namespace TokenAuth.API.MODELS
{
    public class Payment
    {
        public int Id { get; set; }
        //public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        //public InvoiceType InvoiceType { get; set; }
        [Precision (18,2)]
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        
    }
}
