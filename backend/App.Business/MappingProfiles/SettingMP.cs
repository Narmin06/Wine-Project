using App.Core.DTOs.SettingDTOs;
using App.Core.Entities;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class SettingMP : Profile
{
    public SettingMP()
    {
        CreateMap<Setting, SettingDTO>();
        CreateMap<UpdateSettingDTO, Setting>();
    }
}
