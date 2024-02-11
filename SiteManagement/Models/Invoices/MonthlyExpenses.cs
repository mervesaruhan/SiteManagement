using SiteManagement.Models.AparmentInfos;

namespace SiteManagement.Models.Invoices
{
    public class MonthlyExpenses
    {
        public int Id { get; set; }
        public decimal GasBill { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ElectricityBill { get; set; }
        //public decimal Dues { get; set; }

        //public int ApartmentId { get; set; } // Apartment ile ilişki için foreign key
        //public Apartment Apartment { get; set; } // MonthlyExpenses ile Apartment arasında ilişki

    }
}
