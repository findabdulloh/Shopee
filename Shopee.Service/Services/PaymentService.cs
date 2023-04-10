using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Payments;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class PaymentService : IPaymentService
{
    IPaymentRepository repostory = new PaymentRepository();
    IOrderItemService orderItemSer = new OrderItemService();
    IUserRepository userRepo = new UserRepository();
    ICartService cartService = new CartService(); 

    public async Task<Payment> CreateAsync(PaymentCreationDto dto)
    {
        var cart = await cartService.GetByUserIdAsync(dto.UserId);

        var payment = new Payment
        {
            Type = dto.Type,
            IsPaid = dto.Type != PaymentType.Cash,
            CreatedAt = DateTime.UtcNow,
            Amount = cart.TotalPrice
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

        paymentForUpdate.UpdatedAt = DateTime.UtcNow;
        await this.repostory.UpdateAsync(paymentForUpdate);
        await this.repostory.SaveChangesAsync();
        return paymentForUpdate;
    }
}
