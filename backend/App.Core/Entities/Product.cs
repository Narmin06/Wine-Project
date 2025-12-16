using App.Core.Entities.Commons;
using App.Core.Entities.Relations;

namespace App.Core.Entities;

public class Product : AuditableEntity
{
	public string Title { get; set; }
	public decimal Price { get; set; }
	public string ImageUrl { get; set; }
	public float Liter { get; set; }
	public DateTime ProdDate { get; set; }
	public string Location { get; set; }
	public string CompanyIconUrl { get; set; }

	public ICollection<ProductDetail> Details { get; set; }
	public ICollection<ProductField> Fields { get; set; }
	public ICollection<Category> Categories { get; set; }
}
