using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Payments;
using SiteManagement.Models.Users;
using SiteManagement.Models.Users.DTO;

namespace SiteManagement.Models.AdminServices
{
    public interface IAdminService
    {
        void CreateUser(User user);
        void  UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);
        void AssignDuesToApartment(int apartmentId, decimal duesAmount);
        List<Payment> GetPaymentsForApartments();
       
        void AddMonthlyExpenses(decimal electricityBill, decimal waterBill, decimal gasBill);
        public Dictionary<int, decimal> GetMonthlyDebtStatusForApartments(int month, int year);
        Dictionary<int, decimal> GetYearlyDebtStatusForApartments(int year);
        List<User> GetRegularPayingUsersForApartment(int apartmentId);
        void InitializeAdmin();

        List<Payment> GetPaymentsByUserId(int userId);
        List<Apartment> GetApartmentsWithUsers();
    }
}
