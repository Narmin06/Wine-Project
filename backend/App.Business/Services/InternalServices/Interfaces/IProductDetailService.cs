using App.Core.DTOs.ProductDetailDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface IProductDetailService
{
    IQueryable<ProductDetailDTO> GetAll();
    IQueryable<ProductDetailDTO> GetAllActive();
    IQueryable<ProductDetailDTO> GetAllDeleted();
    ProductDetailDTO GetById(int id);
    Task<ProductDetailDTO> AddAsync(CreateProductDetailDTO dto);
    Task<ProductDetailDTO> UpdateAsync(int id, UpdateProductDetailDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}