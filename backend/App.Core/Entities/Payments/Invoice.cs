using App.Core.Entities.Commons;
using App.Core.Entities.Orders;
using App.Core.Enums;

namespace App.Core.Entities.Payments;

public class Invoice:AuditableEntity
{
	public decimal Amount { get; set; }
	public string PaymentUrl { get; set; }
	public string Currency { get; set; } = "AZN";
	public string? PaymentProvider { get; set; }
	public string? ProviderTransactionId { get; set; }
	public EInvoiceStatus Status { get; set; } = EInvoiceStatus.ONPAYMENT;


	public int OrderId { get; set; }
	public Order Order { get; set; }
}
