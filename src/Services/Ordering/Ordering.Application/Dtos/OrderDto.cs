using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos
{
    //exists only for mapping from ordering.api for business logic=>record
    public record OrderDto(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems);
}
