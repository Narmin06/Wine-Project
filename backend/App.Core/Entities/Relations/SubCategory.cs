using App.Core.Entities.Commons;

namespace App.Core.Entities.Relations;

public class SubCategory : AuditableEntity
{
    public string Name { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
