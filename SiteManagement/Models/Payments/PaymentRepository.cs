namespace SiteManagement.Models.Payments
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment payment)
        {
           
            _context.Payments.Add(payment);
            //_context.SaveChanges();
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public decimal GetTotalDebtByApartmentNumberAndYear(int apartmentNumber, int year)
        {
            return _context.Payments
                .Where(p => p.Users.ApartmentNumber == apartmentNumber && p.Year == year)
                .Sum(p => p.Amount);
        }


        public decimal GetTotalDebtByApartmentNumberAndMonth(int apartmentNumber, int month, int year)
        {
            return _context.Payments
                .Where(p => p.Users.ApartmentNumber == apartmentNumber && p.Month == month && p.Year == year)
                .Sum(p => p.Amount);
        }


        public List<Payment> GetPaymentsByUserId(int userId)
        {
            return _context.Payments
                           .Where(p => p.UserId == userId)
                           .ToList();
        }


    }
}
