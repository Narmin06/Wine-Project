using App.Core.Entities.Orders;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
	public OrderItemRepository(AppDbContext context) : base(context) { }
}
