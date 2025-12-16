using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductDTOs;
using App.Core.Entities;
using App.Core.Exceptions.Commons;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IFileManagerService _fileManagerService;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        IFileManagerService fileManagerService,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _fileManagerService = fileManagerService;
        _mapper = mapper;
    }

    public async Task<ProductDTO> AddAsync(CreateProductDTO dto)
    {
        var product = _mapper.Map<Product>(dto);
        var addedProduct = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDTO>(addedProduct);
    }

    public IQueryable<ProductDTO> GetAll()
    {
        var products = _productRepository.GetAll(x => !x.IsDeleted);
        return products.Select(p => _mapper.Map<ProductDTO>(p));
    }

    public IQueryable<ProductDTO> GetAllActive()
    {
        var products = _productRepository.GetAllActive(x => true);
        return products.Select(p => _mapper.Map<ProductDTO>(p));
    }

    public IQueryable<ProductDTO> GetAllDeleted()
    {
        var products = _productRepository.GetAllDeleted(x => true);
        return products.Select(p => _mapper.Map<ProductDTO>(p));
    }

    public ProductDTO GetById(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task RemoveAsync(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productRepository.RemoveAsync(product);
    }

    public async Task<ProductDTO> UpdateAsync(int id, UpdateProductDTO dto)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);

        if (dto.Image != null && !string.IsNullOrWhiteSpace(product.ImageUrl))
        {
            await _fileManagerService.RemoveFileAsync(product.ImageUrl);
        }

        if (dto.Icon != null && !string.IsNullOrWhiteSpace(product.CompanyIconUrl))
        {
            await _fileManagerService.RemoveFileAsync(product.CompanyIconUrl);
        }

        var updatedProduct = _mapper.Map(dto, product);
        var result = await _productRepository.UpdateAsync(updatedProduct);
        return _mapper.Map<ProductDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productRepository.SoftDeleteAsync(product);
    }

    public async Task RecoverAsync(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _productRepository.RecoverAsync(product);
    }

    public async Task ActivateAsync(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productRepository.ActivateAsync(product);
    }

    public async Task DeactivateAsync(int id)
    {
        var product = _productRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productRepository.DeactivateAsync(product);
    }
}