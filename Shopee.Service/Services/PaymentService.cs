using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Payments;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class PaymentService : IPaymentService
{
    IPaymentRepository repostory;
    IOrderItemService orderItemSer;

    public PaymentService(IPaymentRepository repostory, IOrderItemService orderItemSer)
    {
        this.repostory = repostory;
        this.orderItemSer = orderItemSer;
    }

    public async Task<Payment> CreateAsync(PaymentCreationDto dto)
    {
        decimal amount = 0;

        foreach (var item in await orderItemSer.GetAllAsync(u => u.OrderId == dto.OrderId))
        {
            amount += item.Amount;
        }

        var payment = new Payment
        {
            Type = dto.Type,
            IsPaid = dto.Type != PaymentType.Cash,
            CreatedAt = DateTime.UtcNow,
            Amount = amount
        };

        var insertedEntity = await repostory.CreateAsync(payment);

        await this.repostory.SaveChangesAsync();
        return insertedEntity;
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
