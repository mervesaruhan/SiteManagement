namespace SiteManagement.Models.Invoices
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoicesForApartment(int apartmentNumber);
        void MarkInvoiceAsPaid(int invoiceId);
        Invoice GetInvoiceById(int invoiceId);
        decimal GetTotalDebtByApartmentNumber(int apartmentNumber);
        void AddInvoice(Invoice invoice);

        decimal GetTotalDuesByApartmentNumber(int apartmentNumber);

        public decimal GetTotalMonthlyExpensesByApartmentNumber(int apartmentNumber, int month, int year);
        public decimal GetTotalYearlyExpensesByApartmentNumber(int apartmentNumber, int year);
    }
}
