using App.Core.DTOs.SettingDTOs;

namespace App.Business.Services.InternalServices.Interfaces;

public interface ISettingService
{
    Task<SettingDTO> GetSettingAsync();
    Task<SettingDTO> UpdateSettingAsync(UpdateSettingDTO dto);
}
