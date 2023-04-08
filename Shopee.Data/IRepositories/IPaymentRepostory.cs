using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IPaymentRepostory
{
    Task<Payment> CreateAsync(Payment payment);
    Task<Payment> UpdateAsync(Payment payment);
    Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression);
    Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
    Task<List<Payment>> GetAllASync(Expression<Func<Payment, bool>> expression = null);
}
