using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Payments;

namespace Shopee.Service.Interfaces;

public interface IPaymentService
{
    Task<Payment> CreateAsync(PaymentCreationDto dto);
    Task<Payment> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<Payment> ModifyAsync(long id, PaymentCreationDto dto);
    Task<List<Payment>> GetAllAsync();
}
