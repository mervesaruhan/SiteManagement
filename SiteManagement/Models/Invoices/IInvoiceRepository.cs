namespace SiteManagement.Models.Invoices
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoicesForApartment(int apartmentNumber);
        void MarkInvoiceAsPaid(int invoiceId);
        Invoice GetInvoiceById(int invoiceId);
        decimal GetTotalDebtByApartmentNumber(int apartmentNumber);
        void AddInvoice(Invoice invoice);
        void AddMonthlyExpenses(MonthlyExpenses monthlyExpenses);
        void UpdateInvoice(Invoice invoice);
    }
}
