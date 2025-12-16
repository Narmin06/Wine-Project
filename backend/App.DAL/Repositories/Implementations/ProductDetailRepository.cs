using App.Core.Entities.Relations;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
{
	public ProductDetailRepository(AppDbContext context) : base(context) { }
}
