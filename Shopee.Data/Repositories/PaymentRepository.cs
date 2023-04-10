using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Shopee.Data.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Payment> CreateAsync(Payment payment)
    {
        var userForInsert = await this.context.Payments.AddAsync(payment);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
    {
        var PaymentForDelete = await this.context.Payments.FirstOrDefaultAsync(expression);

        this.context.Payments.Remove(PaymentForDelete);
        return true;
    }

    public async Task<List<Payment>> GetAllASync(Expression<Func<Payment, bool>> expression = null)
        => expression is null ? await context.Payments.ToListAsync()
            : await this.context.Payments.Where(expression).ToListAsync();

    public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
    => await this.context.Payments.FirstOrDefaultAsync(expression);

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        return context.Update(payment).Entity;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}