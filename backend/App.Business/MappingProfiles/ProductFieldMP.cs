using App.Core.DTOs.ProductFieldDTOs;
using App.Core.Entities.Relations;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class ProductFieldMP : Profile
{
    public ProductFieldMP()
    {
        CreateMap<ProductField, ProductFieldDTO>()
            .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.Product.Title));

        CreateMap<CreateProductFieldDTO, ProductField>();
        CreateMap<UpdateProductFieldDTO, ProductField>();
    }
}