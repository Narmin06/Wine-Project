using App.Core.DTOs.ProductDetailDTOs;
using App.Core.Entities.Relations;
using AutoMapper;

namespace App.Business.MappingProfiles;

public class ProductDetailMP : Profile
{
    public ProductDetailMP()
    {
        CreateMap<ProductDetail, ProductDetailDTO>()
            .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.Product.Title));

        CreateMap<CreateProductDetailDTO, ProductDetail>();
        CreateMap<UpdateProductDetailDTO, ProductDetail>();
    }
}