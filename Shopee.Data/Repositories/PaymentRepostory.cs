using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;
public class PaymentRepostory : IPaymentRepostory
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Payment> CreateAsync(Payment payment)
    {
        var userForInsert = await this.context.Payments.AddAsync(payment);
        await this.context.SaveChangesAsync();
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
    {
        var PaymentForDelete = await this.context.Payments.FirstOrDefaultAsync(expression);

        this.context.Payments.Remove(PaymentForDelete);
        await this.context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Payment>> GetAllASync(Expression<Func<Payment, bool>> expression = null)
        => await this.context.Payments.ToListAsync();

    public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
    => await this.context.Payments.FirstOrDefaultAsync(expression);

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        var paymentForUpdate = await this.context.Payments.FirstOrDefaultAsync(u => u.Id == payment.Id);

        paymentForUpdate.IsPaid = payment.IsPaid;
        paymentForUpdate.UpdatedAt = DateTime.UtcNow;

        await this.context.SaveChangesAsync();

        return paymentForUpdate;
    }
}
