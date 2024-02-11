using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.AdminServices;
using SiteManagement.Models.AparmentInfos;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.Users;
using System.Transactions;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly AdminInitializer _adminInitializer; 
    private readonly IInvoiceService _invoiceService;
    


    public AdminService(IInvoiceService invoiceService, IUserRepository userRepository, IApartmentRepository apartmentRepository, IInvoiceRepository invoiceRepository, IPaymentRepository paymentRepository, AdminInitializer adminInitializer)
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _invoiceRepository = invoiceRepository;
        _paymentRepository = paymentRepository;
        _adminInitializer = adminInitializer;
        _invoiceService = invoiceService;

    }





    public void InitializeAdmin()
    {
        _adminInitializer.InitializeAdmin();
    }




    // İkamet eden kullanıcı bilgilerini oluşturma işlemi
    public void CreateUser(User user)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                _userRepository.RegisterUser(user);

                transaction.Complete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                transaction.Dispose();
            }
        }
    }



    // İkamet eden kullanıcı bilgilerini güncelleme işlemi
    public void UpdateUser(int userId, User updatedUser)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                _userRepository.UpdateUser(userId, updatedUser);
                transaction.Complete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                transaction.Dispose();
            }
        }
    }


    // İkamet eden kullanıcı bilgilerini silme işlemi
    public void DeleteUser(int userId)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                _userRepository.DeleteUser(userId);
                transaction.Complete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                transaction.Dispose();
            }
        }
    }





    // Daire başına ödenmesi gereken aidat bilgilerini atama işlemi
    public void AssignDuesToApartment(int apartmentNumber, decimal duesAmount)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                var apartment = _apartmentRepository.GetApartmentByNumber(apartmentNumber);
                if (apartment != null)
                {
                    var duesInvoice = new Invoice
                    {
                        Date = DateTime.Now,
                        Amount = duesAmount,
                        InvoiceType = InvoiceType.Dues,
                        IsPaid = false,
                        ApartmentNumber = apartmentNumber,
                        Dues = duesAmount
                    };
                    _invoiceRepository.AddInvoice(duesInvoice);
                }

                transaction.Complete();
                Console.WriteLine("Aidat ataması başarılı!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                transaction.Dispose();
            }
        }
    }




    // Bina olarak ödenmesi gereken fatura bilgilerini girme işlemi
    public void AddMonthlyExpenses(decimal electricityBill, decimal waterBill, decimal gasBill)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                var monthlyExpenses = new MonthlyExpenses
                {
                    ElectricityBill = electricityBill,
                    WaterBill = waterBill,
                    GasBill = gasBill
                };
                _invoiceRepository.AddMonthlyExpenses(monthlyExpenses);

                transaction.Complete();
                Console.WriteLine("Fatura bilgileri başarıı olarak eklendi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                transaction.Dispose();
            }
        }
    }






    // Dairelerin yapmış olduğu ödemeleri görebilme işlemi
    public List<Payment> GetPaymentsForApartments()
    {
        return _paymentRepository.GetAllPayments();
    }

    public List<Payment> GetPaymentsByUserId(int userId)
    {
        return _paymentRepository.GetPaymentsByUserId(userId);
    }


    //apartmanlar ve bunlara bağlı kullanıcıları görebilme
    public List<Apartment> GetApartmentsWithUsers()
    {
        return _apartmentRepository.GetApartmentsWithUsers();
    }





    //AYLIK OLARAK DAİRE BASINA DÜŞEN BORÇ DURUMUNU GÖREBİLME

    public Dictionary<int, decimal> GetMonthlyDebtStatusForApartments(int month, int year)
    {
        var debtStatus = new Dictionary<int, decimal>();

        var apartments = _apartmentRepository.GetAllApartments();
        foreach (var apartment in apartments)
        {
            // Dairenin aylık borç durumunu hesaplama işlemi
            var totalDues = _invoiceService.GetTotalDuesByApartmentNumber(apartment.ApartmentNumber);
            var totalMonthlyExpenses = _invoiceService.GetTotalMonthlyExpensesByApartmentNumber(apartment.ApartmentNumber, month, year);
            var totalPayments = _paymentRepository.GetTotalDebtByApartmentNumberAndMonth(apartment.ApartmentNumber, month, year);
            var debt = totalDues + totalMonthlyExpenses - totalPayments;

            debtStatus.Add(apartment.ApartmentNumber, debt);
        }

        return debtStatus;
    }

    //YILLIK OLARAK DAİRE BASINA DÜŞEN BORÇ DURUMUNU GÖREBİLME


    public Dictionary<int, decimal> GetYearlyDebtStatusForApartments(int year)
    {
        var debtStatus = new Dictionary<int, decimal>();

        var apartments = _apartmentRepository.GetAllApartments();
        foreach (var apartment in apartments)
        {
            // Dairenin yıllık borç durumunu hesaplama işlemi
            var totalDues = _invoiceService.GetTotalDuesByApartmentNumber(apartment.ApartmentNumber);
            var totalYearlyExpenses = _invoiceService.GetTotalYearlyExpensesByApartmentNumber(apartment.ApartmentNumber, year);
            var totalPayments = _paymentRepository.GetTotalDebtByApartmentNumberAndYear(apartment.ApartmentNumber, year);
            var debt = totalDues + totalYearlyExpenses - totalPayments;

            debtStatus.Add(apartment.Id, debt);
        }

        return debtStatus;
    }





    //BONUS:DÜZENLİ ÖDEME YAPAN KULLANICILARI GÖRME
    public List<User> GetRegularPayingUsersForApartment(int apartmentNumber)
    {
       
        var users = _userRepository.GetUsersByApartmentNumber(apartmentNumber);

        
        var regularPayingUsers = new List<User>();

        foreach (var user in users)
        {
            
            var payments = _paymentRepository.GetPaymentsByUserId(user.Id);

            
            bool isRegularPayer = true;
            foreach (var payment in payments)
            {
                
                if (payment.PaymentDate.AddMonths(1) < DateTime.Now)
                {
                    isRegularPayer = false;
                    break;
                }
            }

           
            if (isRegularPayer)
            {
                regularPayingUsers.Add(user);
            }
        }

        return regularPayingUsers;
    }

}
