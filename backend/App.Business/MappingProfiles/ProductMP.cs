using App.Core.DTOs.ProductDTOs;
using App.Core.Entities;
using App.Business.MappingProfiles.Commons;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class ProductMP : Profile
{
    public ProductMP()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();

        CreateMap<CreateProductDTO, Product>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.CompanyIconUrl, opt => opt.Ignore())
            .AfterMap<CustomMappingAction<CreateProductDTO, Product>>();

        CreateMap<UpdateProductDTO, Product>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.CompanyIconUrl, opt => opt.Ignore())
            .AfterMap<CustomMappingAction<UpdateProductDTO, Product>>();
    }
}