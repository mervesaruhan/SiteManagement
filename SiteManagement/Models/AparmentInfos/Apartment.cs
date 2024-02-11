using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.Users;

namespace SiteManagement.Models.AparmentInfos
{
    public class Apartment
    {
        public int Id { get; set; }
        public string BlockInfo { get; set; } = default!;
        public bool IsOccupied { get; set; } 
        public string? Type { get; set; } 
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; } 
        public string? OwnerOrTenant { get; set; }
        //public User Users { get; set; }
        //public Payment Payments { get; set; }
        //public Invoice Invoices { get; set; }

        //public List<Invoice> Invoices { get; set; }
        public virtual ICollection<User> Users { get; set; } // Apartmana ait kullanıcılar koleksiyonu
        public virtual ICollection<Payment> Payments { get; set; } // Apartmana ait ödemeler koleksiyonu
        public virtual ICollection<Invoice> Invoices { get; set; } // Apartmana ait faturalar koleksiyonu

    }
}
