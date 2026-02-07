using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{ 
    //pagination is to get all orders(based on how much we need rn)
    public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
