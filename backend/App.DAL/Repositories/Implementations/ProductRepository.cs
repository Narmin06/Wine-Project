using App.Core.Entities;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
	public ProductRepository(AppDbContext context) : base(context) { }
}
