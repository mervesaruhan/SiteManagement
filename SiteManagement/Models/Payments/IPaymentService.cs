using SiteManagement.Models.Invoices;

namespace SiteManagement.Models.Payments
{
    public interface IPaymentService
    {
        void MakePayment(int userId, Invoice invoice, InvoiceType paymentType, PaymentMethod paymentMethod, decimal amount, int year, int month);

        decimal GetTotalDebtByApartmentNumberAndYear(int apartmentNumber, int year);
        decimal GetTotalDebtByApartmentNumberAndMonth(int apartmentNumber, int month, int year);

    }
}
