using App.Core.DTOs.CategoryDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface ICategoryService
{
    IQueryable<CategoryDTO> GetAll();
    IQueryable<CategoryDTO> GetAllActive();
    IQueryable<CategoryDTO> GetAllDeleted();
    CategoryDTO GetById(int id);
    Task<CategoryDTO> AddAsync(CreateCategoryDTO dto);
    Task<CategoryDTO> UpdateAsync(int id, UpdateCategoryDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}