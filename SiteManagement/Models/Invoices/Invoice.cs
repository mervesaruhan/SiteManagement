using SiteManagement.Models.AparmentInfos;

namespace SiteManagement.Models.Invoices
{
    
    public class Invoice
    {
       
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public decimal Dues { get; set; }
        public bool IsPaid { get; set; } 

        public int ApartmentNumber { get; set; } 
        public Apartment Apartments { get; set; }

        //public int MonthlyExpensesId { get; set; } // MonthlyExpenses ile ilişki için foreign key
        //public MonthlyExpenses MonthlyExpenses { get; set; }

    }
}
