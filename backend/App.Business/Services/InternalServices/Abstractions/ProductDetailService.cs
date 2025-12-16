using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductDetailDTOs;
using App.Core.Entities.Relations;
using App.Core.Exceptions.Commons;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class ProductDetailService : IProductDetailService
{
    private readonly IProductDetailRepository _productDetailRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductDetailService(
        IProductDetailRepository productDetailRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productDetailRepository = productDetailRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailDTO> AddAsync(CreateProductDetailDTO dto)
    {
        var product = _productRepository.GetById(x => x.Id == dto.ProductId && !x.IsDeleted);
        var productDetail = _mapper.Map<ProductDetail>(dto);
        var addedProductDetail = await _productDetailRepository.AddAsync(productDetail);
        return _mapper.Map<ProductDetailDTO>(addedProductDetail);
    }

    public IQueryable<ProductDetailDTO> GetAll()
    {
        var productDetails = _productDetailRepository.GetAll(x => !x.IsDeleted);
        return productDetails.Select(pd => _mapper.Map<ProductDetailDTO>(pd));
    }

    public IQueryable<ProductDetailDTO> GetAllActive()
    {
        var productDetails = _productDetailRepository.GetAllActive(x => true);
        return productDetails.Select(pd => _mapper.Map<ProductDetailDTO>(pd));
    }

    public IQueryable<ProductDetailDTO> GetAllDeleted()
    {
        var productDetails = _productDetailRepository.GetAllDeleted(x => true);
        return productDetails.Select(pd => _mapper.Map<ProductDetailDTO>(pd));
    }

    public ProductDetailDTO GetById(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<ProductDetailDTO>(productDetail);
    }

    public async Task RemoveAsync(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productDetailRepository.RemoveAsync(productDetail);
    }

    public async Task<ProductDetailDTO> UpdateAsync(int id, UpdateProductDetailDTO dto)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        var product = _productRepository.GetById(x => x.Id == dto.ProductId && !x.IsDeleted);
        var updatedProductDetail = _mapper.Map(dto, productDetail);
        var result = await _productDetailRepository.UpdateAsync(updatedProductDetail);
        return _mapper.Map<ProductDetailDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productDetailRepository.SoftDeleteAsync(productDetail);
    }

    public async Task RecoverAsync(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _productDetailRepository.RecoverAsync(productDetail);
    }

    public async Task ActivateAsync(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productDetailRepository.ActivateAsync(productDetail);
    }

    public async Task DeactivateAsync(int id)
    {
        var productDetail = _productDetailRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productDetailRepository.DeactivateAsync(productDetail);
    }
}