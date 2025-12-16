using App.Core.Entities.Commons;

namespace App.Core.Entities.Relations;

public class ProductField : AuditableEntity
{
    public string Key { get; set; }
    public string Value { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
