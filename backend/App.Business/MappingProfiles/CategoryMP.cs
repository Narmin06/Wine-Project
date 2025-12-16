using App.Core.DTOs.CategoryDTOs;
using App.Core.Entities.Relations;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class CategoryMP : Profile
{
    public CategoryMP()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<CreateCategoryDTO, Category>();
        CreateMap<UpdateCategoryDTO, Category>();
    }
}