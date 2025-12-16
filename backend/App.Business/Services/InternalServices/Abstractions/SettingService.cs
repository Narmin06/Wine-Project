using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SettingDTOs;
using App.Core.Entities;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Business.Services.InternalServices.Abstractions;

public class SettingService : ISettingService
{
    private readonly ISettingRepository _settingRepository;
    private readonly IMapper _mapper;
    public SettingService(ISettingRepository settingRepository, IMapper mapper)
    {
        _settingRepository = settingRepository;
        _mapper = mapper;
    }

    public async Task<SettingDTO> GetSettingAsync()
    {   
        var setting = await (_settingRepository.GetAll(x => true)).FirstOrDefaultAsync();

        return _mapper.Map<SettingDTO>(setting);
    }

    public async Task<SettingDTO> UpdateSettingAsync(UpdateSettingDTO dto)
    {
        var setting = await (_settingRepository.GetAll(x => true)).FirstOrDefaultAsync();

        _mapper.Map(dto, setting);
        var updatedSetting = await _settingRepository.UpdateAsync(setting);

        return _mapper.Map<SettingDTO>(updatedSetting);
    }
}
