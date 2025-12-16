using App.Core.Entities.Commons;

namespace App.Core.Entities.Orders;

public class OrderItem : AuditableEntity
{
	public int OrderId { get; set; }
	public Order Order { get; set; }

	public int ProductId { get; set; }
	public Product Product { get; set; }

	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public decimal Total => Price * Quantity;
}
