using App.Core.Entities.Relations;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context) { }
}
