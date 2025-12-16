using App.Core.DTOs.ProductDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface IProductService
{
    IQueryable<ProductDTO> GetAll();
    IQueryable<ProductDTO> GetAllActive();
    IQueryable<ProductDTO> GetAllDeleted();
    ProductDTO GetById(int id);
    Task<ProductDTO> AddAsync(CreateProductDTO dto);
    Task<ProductDTO> UpdateAsync(int id, UpdateProductDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}