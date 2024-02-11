using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Users;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.Payments;
using SiteManagement.Models.AdminServices;
using Microsoft.AspNetCore.Authorization;
using SiteManagement.Models.Users.Requests;

namespace SiteManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AdminController(IAdminService adminService,IUserService userService, ITokenService tokenService)
        {
            _adminService = adminService;
            _userService = userService;
            _tokenService=tokenService;
        }


        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] AuthenticationRequest model)
        {
            var user = _userService.AuthenticateUser(model.TcNo, model.PhoneNumber);

            if (user == null)
                return Unauthorized(new { message = "TC No veya telefon numarası yanlış." });

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }


        [Authorize]
        [HttpPost("users")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                _adminService.CreateUser(user);
                return Ok(new { message = "Kullanıcı başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [Authorize]
        [HttpPut("users/{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User updatedUser)
        {
            try
            {
                _adminService.UpdateUser(userId, updatedUser);
                return Ok(new { message = "Kullanıcı başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [Authorize]
        [HttpDelete("users/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _adminService.DeleteUser(userId);
                return Ok(new { message = "Kullanıcı başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("Payment_usrid")]
        public IActionResult GetPaymentsByUserId(int userId)
        {
            try
            {
                var payments = _adminService.GetPaymentsByUserId(userId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetApartmentsWithUsers()
        {
            try
            {
                var apartments = _adminService.GetApartmentsWithUsers();
                return Ok(apartments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [Authorize]
        [HttpPost("apartments/{apartmentId}/dues")]
        public IActionResult AssignDuesToApartment(int apartmentId, decimal duesAmount)
        {
            try
            {
                _adminService.AssignDuesToApartment(apartmentId, duesAmount);
                return Ok(new { message = "Daireye aidat başarıyla atanmıştır." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("expenses")]
        public IActionResult AddMonthlyExpenses([FromBody] MonthlyExpenses expenses)
        {
            try
            {
                _adminService.AddMonthlyExpenses(expenses.ElectricityBill, expenses.WaterBill, expenses.GasBill);
                return Ok(new { message = "Aylık giderler başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("payments")]
        public IActionResult GetPaymentsForApartments()
        {
            try
            {
                var payments = _adminService.GetPaymentsForApartments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [Authorize]
        [HttpGet("debt/monthly")]
        public IActionResult GetMonthlyDebtStatusForApartments(int month, int year)
        {
            try
            {
                var debtStatus = _adminService.GetMonthlyDebtStatusForApartments(month, year);
                return Ok(debtStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [Authorize]
        [HttpGet("debt/yearly")]
        public IActionResult GetYearlyDebtStatusForApartments(int year)
        {
            try
            {
                var debtStatus = _adminService.GetYearlyDebtStatusForApartments(year);
                return Ok(debtStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }




        [Authorize]
        [HttpGet("regularpayingusers/{apartmentId}")]
        public IActionResult GetRegularPayingUsersForApartment(int apartmentId)
        {
            try
            {
                var regularPayingUsers = _adminService.GetRegularPayingUsersForApartment(apartmentId);
                return Ok(regularPayingUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
