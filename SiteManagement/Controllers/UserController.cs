using Microsoft.AspNetCore.Mvc;

namespace SiteManagement.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SiteManagement.Models.Invoices;
    using SiteManagement.Models.Payments;
    using SiteManagement.Models.Users;
    using SiteManagement.Models.Users.Requests;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
            
            


        public UserController(IUserService userService, IPaymentService paymentService, IInvoiceService invoiceService)
        {
            _userService = userService;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest model)
        {
            var user = _userService.AuthenticateUser(model.TcNo, model.PhoneNumber);

            if (user == null)
                return Unauthorized(new { message = "TC No veya telefon numarası yanlış." });

            return Ok(user);
        }

        [HttpGet("{phoneNumber}")]
        public IActionResult GetUserByPhoneNumber(string phoneNumber)
        {
            var user = _userService.GetUserByPhoneNumber(phoneNumber);
            if (user == null)
                return NotFound();

            return Ok(user);
        }



       

        [HttpGet("{tcNo, phoneNumber}/bills")]
        public IActionResult GetBills(string tc, string phoneNumber)
        {
            var user = _userService.GetUserByTcNoAndPhoneNumber(tc, phoneNumber);
            if (user == null)
                return NotFound();

            
            var bills = _userService.GetInvoicesForUser(tc, phoneNumber);

            return Ok(bills);
        }



        [HttpPost("{userId}/pay")]
        public IActionResult PayBill(int userId, [FromBody] PayBillRequest model)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                    return NotFound(new { message = "Kullanıcı bulunamadı." });

                var invoice = _invoiceService.GetInvoiceById(model.InvoiceId);

                if (invoice == null)
                    return NotFound(new { message = "Fatura bulunamadı." });

                // PaymentType ve PaymentMethod alanlarını uygun türlere çevirme
                var paymentType = Enum.Parse<InvoiceType>(model.PaymentType);
                var paymentMethod = Enum.Parse<PaymentMethod>(model.PaymentMethod);

                _paymentService.MakePayment(userId, invoice, paymentType, paymentMethod, model.Amount, DateTime.Now.Year, DateTime.Now.Month);
                return Ok(new { message = "Ödeme başarıyla gerçekleştirildi." });
            
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }

}
