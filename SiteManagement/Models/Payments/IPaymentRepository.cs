namespace SiteManagement.Models.Payments
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        List<Payment> GetAllPayments();

        decimal GetTotalDebtByApartmentNumberAndYear(int apartmentNumber, int year);
        decimal GetTotalDebtByApartmentNumberAndMonth(int apartmentNumber, int month, int year);

        List<Payment> GetPaymentsByUserId(int userId);
    }
}
