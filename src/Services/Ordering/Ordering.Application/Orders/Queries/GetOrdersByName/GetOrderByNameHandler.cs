namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrderByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                 .Include(o => o.OrderItems)
                 .AsNoTracking() //use when only read data without modifying it=>impove performance
                 .Where(o => o.OrderName.Value.Contains(query.Name))
                 .OrderBy(o => o.OrderName.Value)
                 .ToListAsync(cancellationToken);

            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}
