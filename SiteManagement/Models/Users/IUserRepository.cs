using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;

namespace SiteManagement.Models.Users
{
    public interface IUserRepository
    {
        List<Invoice> GetInvoicesForUser(int apartmentNumber);
        void PayInvoice(int invoiceId);
        User GetUserByTcNoAndPhoneNumber(string tcNo, string phoneNumber);
        void RegisterUser(User user);
        User GetUserById(int userId);
        void UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);

        List<User> GetUsersByApartmentNumber(int apartmentNumber);
        User GetUserByPhoneNumber(string phoneNumber);


    }
}
