using App.Core.DTOs.SlideDTOs;
using App.Core.Entities;
using App.Business.MappingProfiles.Commons;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class SlideMP : Profile
{
    public SlideMP()
    {
        CreateMap<Slide, SlideDTO>().ReverseMap();
        
        CreateMap<CreateSlideDTO, Slide>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .AfterMap<CustomMappingAction<CreateSlideDTO, Slide>>();
        
        CreateMap<UpdateSlideDTO, Slide>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .AfterMap<CustomMappingAction<UpdateSlideDTO, Slide>>();
    }
}