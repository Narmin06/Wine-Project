using App.Core.Entities.Commons;

namespace App.Core.Entities.Relations;

public class Category : AuditableEntity
{
    public string Name { get; set; }

    public ICollection<SubCategory> SubCategories { get; set; }
}
