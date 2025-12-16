using App.Core.Entities.Relations;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class ProductFieldRepository : Repository<ProductField>, IProductFieldRepository
{
	public ProductFieldRepository(AppDbContext context) : base(context) { }
}
