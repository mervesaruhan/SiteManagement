using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.AdminServices;
using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.Users;

namespace SiteManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MonthlyExpenses> MonthlyExpenses { get; set; }
        
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().Property(x => x.Amount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Invoice>().Property(x => x.Dues).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<MonthlyExpenses>().Property(x => x.GasBill).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<MonthlyExpenses>().Property(x => x.WaterBill).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<MonthlyExpenses>().Property(x => x.ElectricityBill).HasColumnType("decimal(18, 2)");

            //modelBuilder.Entity<User>().HasOne(x => x.Apartments).WithMany(x => x.Users).HasForeignKey(x => x.ApartmentId);
            //modelBuilder.Entity<User>().HasMany(x => x.Payments).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            //modelBuilder.Entity<Payment>().HasOne(x => x.Apartments).WithMany(x => x.Payments).HasForeignKey(x => x.ApartmentId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
