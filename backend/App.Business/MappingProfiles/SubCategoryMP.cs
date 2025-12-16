using App.Core.DTOs.SubCategoryDTOs;
using App.Core.Entities.Relations;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class SubCategoryMP : Profile
{
    public SubCategoryMP()
    {
        CreateMap<SubCategory, SubCategoryDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateSubCategoryDTO, SubCategory>();
        CreateMap<UpdateSubCategoryDTO, SubCategory>();
    }
}