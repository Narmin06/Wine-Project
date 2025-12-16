using App.Core.Entities.Commons;
using App.Core.Entities.Identity;

namespace App.Core.Entities.Orders;

public class Order : AuditableEntity
{
	public decimal Subtotal { get; set; }
	public decimal Discount { get; set; }
	public decimal ShippingPrice { get; set; }
	public decimal Total { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

	public string UserId { get; set; }
	public User User { get; set; }

	public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
