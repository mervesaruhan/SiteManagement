namespace SiteManagement.Models.Invoices
{
    public class InvoiceRepository:IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Invoice> GetInvoicesForApartment(int apartmentNumber)
        {
            return _context.Invoices
                .Where(i => i.ApartmentNumber == apartmentNumber)
                .ToList();
        }

        public void MarkInvoiceAsPaid(int invoiceId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == invoiceId);
            if (invoice != null)
            {
                invoice.IsPaid = true;
                _context.SaveChanges();
            }
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return _context.Invoices.FirstOrDefault(i => i.Id == invoiceId);
        }

        public decimal GetTotalDebtByApartmentNumber(int apartmentNumber)
        {
            var unpaidInvoices = _context.Invoices
                .Where(i => i.ApartmentNumber == apartmentNumber && !i.IsPaid)
                .ToList();

            decimal totalDebt = 0;

            foreach (var invoice in unpaidInvoices)
            {
                totalDebt += invoice.Amount;
            }

            return totalDebt;
        }
        public void AddInvoice(Invoice invoice)
        {

            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }


        public void AddMonthlyExpenses(MonthlyExpenses monthlyExpenses)
        {
            // MonthlyExpenses nesnesini veritabanına ekleyecek kod
            _context.MonthlyExpenses.Add(monthlyExpenses);

            // Değişiklikleri kaydet
            //_context.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            //_context.SaveChanges();
        }





    }

    
}
