using Microsoft.EntityFrameworkCore;

namespace SiteManagement.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // Belirli bir daireye ait faturaları getirme işlemi
        public List<Invoice> GetInvoicesForApartment(int apartmentNumber)
        {
            return _invoiceRepository.GetInvoicesForApartment(apartmentNumber);
        }

        // Belirli bir faturayı ödenmiş olarak işaretleme işlemi
        public void MarkInvoiceAsPaid(int invoiceId)
        {
            _invoiceRepository.MarkInvoiceAsPaid(invoiceId);
        }
        public Invoice GetInvoiceById(int invoiceId)
        {
            return _invoiceRepository.GetInvoiceById(invoiceId);
        }

        public decimal GetTotalDebtByApartmentNumber(int apartmentNumber)
        {
            return _invoiceRepository.GetTotalDebtByApartmentNumber(apartmentNumber);
        }
        public void AddInvoice(Invoice invoice)
        {
            var newInvoice = new Invoice
            {
                Date = DateTime.Now,
                Amount = invoice.Amount,
                InvoiceType = invoice.InvoiceType,
                Dues = invoice.Dues,
                IsPaid = invoice.IsPaid,
                ApartmentNumber = invoice.ApartmentNumber
            };
            _invoiceRepository.AddInvoice(newInvoice);
        }

        public MonthlyExpenses CalculateMonthlyExpenses(int apartmentNumber)
        {
            // Daireye ait faturaları al
            var invoices = _invoiceRepository.GetInvoicesForApartment(apartmentNumber);

            // Faturaların toplamını hesapla
            decimal totalGasBill = 0;
            decimal totalWaterBill = 0;
            decimal totalElectricityBill = 0;

            foreach (var invoice in invoices)
            {
                switch (invoice.InvoiceType)
                {
                    case InvoiceType.Gas:
                        totalGasBill += invoice.Amount;
                        break;
                    case InvoiceType.Water:
                        totalWaterBill += invoice.Amount;
                        break;
                    case InvoiceType.Electricity:
                        totalElectricityBill += invoice.Amount;
                        break;
                }
            }

            // Toplam fatura miktarlarını MonthlyExpenses nesnesine aktar
            var monthlyExpenses = new MonthlyExpenses
            {
                GasBill = totalGasBill,
                WaterBill = totalWaterBill,
                ElectricityBill = totalElectricityBill,
            };

            return monthlyExpenses;
        }


        public decimal GetTotalDuesByApartmentNumber(int apartmentNumber)
        {
            var invoices = _invoiceRepository.GetInvoicesForApartment(apartmentNumber);
            decimal totalDues = 0;

            foreach (var invoice in invoices)
            {
                if (invoice.InvoiceType == InvoiceType.Dues)
                {
                    totalDues += invoice.Amount;
                }
            }

            return totalDues;
        }


        public decimal GetTotalMonthlyExpensesByApartmentNumber(int apartmentNumber, int month, int year)
        {
            var invoices = _invoiceRepository.GetInvoicesForApartment(apartmentNumber);
            decimal totalMonthlyExpenses = 0;

            foreach (var invoice in invoices)
            {
                if (invoice.InvoiceType != InvoiceType.Dues && invoice.Date.Month == month && invoice.Date.Year == year)
                {
                    totalMonthlyExpenses += invoice.Amount;
                }
            }

            return totalMonthlyExpenses;
        }

        public decimal GetTotalYearlyExpensesByApartmentNumber(int apartmentNumber, int year)
        {
            var invoices = _invoiceRepository.GetInvoicesForApartment(apartmentNumber);
            decimal totalYearlyExpenses = 0;

            foreach (var invoice in invoices)
            {
                if (invoice.InvoiceType != InvoiceType.Dues && invoice.Date.Year == year)
                {
                    totalYearlyExpenses += invoice.Amount;
                }
            }

            return totalYearlyExpenses;
        }
    }
    

}


