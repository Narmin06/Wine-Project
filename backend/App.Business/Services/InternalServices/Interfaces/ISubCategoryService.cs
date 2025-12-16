using App.Core.DTOs.SubCategoryDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface ISubCategoryService
{
    IQueryable<SubCategoryDTO> GetAll();
    IQueryable<SubCategoryDTO> GetAllActive();
    IQueryable<SubCategoryDTO> GetAllDeleted();
    SubCategoryDTO GetById(int id);
    Task<SubCategoryDTO> AddAsync(CreateSubCategoryDTO dto);
    Task<SubCategoryDTO> UpdateAsync(int id, UpdateSubCategoryDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}