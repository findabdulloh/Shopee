using Shopee.Domain.Commons;
using System.Net;

namespace Shopee.Domain.Entities;

public class Cart : Auditable
{
    public List<long> OrderItemIds { get; set; }
}
