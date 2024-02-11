using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.UnitOfWork;
using System.Security.Authentication;

namespace SiteManagement.Models.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        

        public UserService(IUserRepository userRepository, IPaymentRepository paymentRepository, IInvoiceRepository invoiceRepository)
        {
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
        }



        public User GetUserByPhoneNumber(string phoneNumber)
        {
            return _userRepository.GetUserByPhoneNumber(phoneNumber);
        }



        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }



        public List<Invoice> GetInvoicesForUser(string tcNo, string phoneNumber)
        {
            var user = _userRepository.GetUserByTcNoAndPhoneNumber(tcNo, phoneNumber);
            if (user != null)
            {
                return _invoiceRepository.GetInvoicesForApartment(user.ApartmentNumber);
            }
            return new List<Invoice>();
        }


        public User GetUserByTcNoAndPhoneNumber(string tcNo, string phoneNumber)
        {
            return _userRepository.GetUserByTcNoAndPhoneNumber(tcNo, phoneNumber);
        }



        public User AuthenticateUser(string tcNo, string phoneNumber)
        {
            //return _userRepository.GetUserByTcNoAndPhoneNumber( tcNo, phoneNumber);
            var user = _userRepository.GetUserByTcNoAndPhoneNumber(tcNo, phoneNumber);
            if (user != null)
            {
                // Kullanıcı doğrulandıktan sonra diğer bilgileri döndür
                return user;
            }
            throw new AuthenticationException("Kullanıcı doğrulanamadı. TC No veya telefon numarasını kontrol edin.");
        }
    }
}
