using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Invoices;
using SiteManagement.Models.UnitOfWork;

namespace SiteManagement.Models.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IPaymentRepository paymentRepository, IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }


        public void MakePayment(int userId, Invoice invoice, InvoiceType paymentType, PaymentMethod paymentMethod, decimal amount, int year, int month)
        {
            using (var transaction = _unitOfWork.BeginTransaction()) 
            {
                try
                {
                   
                    var payment = new Payment
                    {
                        PaymentMethod = paymentMethod,
                        PaymentDate = DateTime.Now,
                        InvoiceType = paymentType,
                        Amount = amount,
                        Year = year,
                        Month = month,
                        UserId = userId
                    };

                    
                    _paymentRepository.AddPayment(payment);

                    
                    invoice.IsPaid = true;
                    _invoiceRepository.UpdateInvoice(invoice);

                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    
                    transaction.Rollback();
                    throw new Exception("Ödeme işlemi sırasında bir hata oluştu.", ex);
                }
            }
        }





        public decimal GetTotalDebtByApartmentNumberAndYear(int apartmentNumber, int year)
        {
            return _paymentRepository.GetTotalDebtByApartmentNumberAndYear(apartmentNumber, year);
        }

       

        public decimal GetTotalDebtByApartmentNumberAndMonth(int apartmentNumber, int month, int year)
        {
            return _paymentRepository.GetTotalDebtByApartmentNumberAndMonth(apartmentNumber,month, year);
        }
    }
}
