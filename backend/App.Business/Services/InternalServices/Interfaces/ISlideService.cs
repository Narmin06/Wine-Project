using App.Core.DTOs.SlideDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface ISlideService
{
    IQueryable<SlideDTO> GetAll();
    IQueryable<SlideDTO> GetAllActive();
    IQueryable<SlideDTO> GetAllDeleted();
    SlideDTO GetById(int id);
    Task<SlideDTO> AddAsync(CreateSlideDTO dto);
    Task<SlideDTO> UpdateAsync(int id, UpdateSlideDTO dto);
    Task RemoveAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task ActivateAsync(int id);
    Task DeactivateAsync(int id);
}