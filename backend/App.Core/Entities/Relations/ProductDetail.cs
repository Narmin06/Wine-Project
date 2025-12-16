using App.Core.Entities.Commons;

namespace App.Core.Entities.Relations;

public class ProductDetail : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
