using App.Core.Entities.Orders;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class OrderRepository : Repository<Order>, IOrderRepository
{
	public OrderRepository(AppDbContext context) : base(context) { }
}
