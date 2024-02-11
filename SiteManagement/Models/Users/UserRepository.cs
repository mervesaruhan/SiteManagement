using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;

namespace SiteManagement.Models.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }



        public List<Invoice> GetInvoicesForUser(int apartmentNumber)
        {
            return _context.Invoices
                .Where(i => i.ApartmentNumber == apartmentNumber)
                .ToList();
        }

        public void PayInvoice(int invoiceId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == invoiceId);
            if (invoice != null)
            {
                invoice.IsPaid = true; // Faturayı ödendi olarak işaretle
                _context.SaveChanges();
            }
        }

        

        public  User GetUserByTcNoAndPhoneNumber(string tcNo, string phoneNumber)
        {
            return _context.Users.FirstOrDefault(u => u.TcNo == tcNo && u.PhoneNumber == phoneNumber);
        }


        public User GetUserByPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null){
                throw new Exception("Nuarayla eşlesen kullanıcı bulunamadı!");
            }
            return _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }





        

        //bundan sonrası yetkilendirmeyle ele alınacak

        public void RegisterUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                SurName = user.SurName,
                TcNo = user.TcNo,
                Email = user.Email,
                PhoneNumber= user.PhoneNumber
            };
         

            _context.Users.Add(user);
            //_context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            if (userId == null)
            {
                throw new Exception("Eşleşen kullanıcı yok!");
            }
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (existingUser == null)
            {
                throw new Exception("Kullanıcı bulunamadı!");
            }

            
            existingUser.Name = updatedUser.Name;
            existingUser.SurName = updatedUser.SurName;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.Email = updatedUser.Email;
            existingUser.TcNo = updatedUser.TcNo;
            existingUser.UserRole = updatedUser.UserRole;

           
            _context.Users.Update(existingUser);
            //_context.SaveChanges();
        }



        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                //_context.SaveChanges();
            }
        }

        public List<User> GetUsersByApartmentNumber(int apartmentNumber)
        {
            return _context.Users
                           .Where(u => u.ApartmentNumber == apartmentNumber)
                           .ToList();
        }
    }
}
