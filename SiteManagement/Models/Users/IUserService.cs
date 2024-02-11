using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;

namespace SiteManagement.Models.Users
{
    public interface IUserService
    {
        List<Invoice> GetInvoicesForUser(string tcNo, string phoneNumber);

        User AuthenticateUser(string tcNo, string phoneNumber);
        User GetUserByPhoneNumber(string phoneNumber);
        User GetUserById(int userId);
        User GetUserByTcNoAndPhoneNumber(string tcNo, string phoneNumber);
    }
}
