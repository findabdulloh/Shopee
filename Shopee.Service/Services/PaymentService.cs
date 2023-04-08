using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Payments;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class PaymentService : IPaymentService
{
    IPaymentRepostory repostory;

    public PaymentService(IPaymentRepostory repostory)
    {
        this.repostory = repostory;
    }

    public Task<Payment> CreateAsync(PaymentCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var paymentExist = await this.repostory.GetAsync(u=> u.Id == id);
        if(paymentExist is null)
            return false;
        
        await this.repostory.DeleteAsync(u=> u.Id == id);
        await this.repostory.SaveChangesAsync();
        return true;
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        var payments = await this.repostory.GetAllASync();
        return payments;
    }

    public async Task<Payment> GetByIdAsync(long id)
    {
        var payment = await this.repostory.GetAsync(u=> u.Id == id);
        if(payment is null)
            return null;

        return payment;
    }

    public async Task<Payment> ModifyAsync(long id, PaymentCreationDto dto)
    {
        var paymentForUpdate = await this.repostory.GetAsync(u=> u.Id == id);
        if(paymentForUpdate is null)
            return null;

        await this.repostory.UpdateAsync(paymentForUpdate);
        await this.repostory.SaveChangesAsync();
        return paymentForUpdate;
    }
}
