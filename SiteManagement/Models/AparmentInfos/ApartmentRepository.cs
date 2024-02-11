using Microsoft.EntityFrameworkCore;

namespace SiteManagement.Models.AparmentInfos
{
    public class ApartmentRepository:IApartmentRepository
    {
        private readonly AppDbContext _context;

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }

        public List<Apartment> GetAllApartments()
        {
            return _context.Apartments.ToList();
        }

        public Apartment GetApartmentByNumber(int apartmentNumber)
        {
            return _context.Apartments.FirstOrDefault(a => a.ApartmentNumber == apartmentNumber);
        }

        public void UpdateApartment(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
            _context.SaveChanges();
        }

        public void DeleteApartment(int apartmentNumber)
        {
            var apartment = _context.Apartments.FirstOrDefault(a => a.ApartmentNumber == apartmentNumber);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                _context.SaveChanges();
            }
        }

        public List<Apartment> GetApartmentsWithUsers()
        {
            return _context.Apartments.Include(a => a.Users).ToList();
        }


    }
}
