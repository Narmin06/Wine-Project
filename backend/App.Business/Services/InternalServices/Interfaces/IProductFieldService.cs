using App.Core.DTOs.ProductFieldDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface IProductFieldService
{
    IQueryable<ProductFieldDTO> GetAll();
    IQueryable<ProductFieldDTO> GetAllActive();
    IQueryable<ProductFieldDTO> GetAllDeleted();
    ProductFieldDTO GetById(int id);
    Task<ProductFieldDTO> AddAsync(CreateProductFieldDTO dto);
    Task<ProductFieldDTO> UpdateAsync(int id, UpdateProductFieldDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}