using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductFieldDTOs;
using App.Core.Entities.Relations;
using App.Core.Exceptions.Commons;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class ProductFieldService : IProductFieldService
{
    private readonly IProductFieldRepository _productFieldRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductFieldService(
        IProductFieldRepository productFieldRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productFieldRepository = productFieldRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductFieldDTO> AddAsync(CreateProductFieldDTO dto)
    {
        var product = _productRepository.GetById(x => x.Id == dto.ProductId && !x.IsDeleted);
        var productField = _mapper.Map<ProductField>(dto);
        var addedProductField = await _productFieldRepository.AddAsync(productField);
        return _mapper.Map<ProductFieldDTO>(addedProductField);
    }

    public IQueryable<ProductFieldDTO> GetAll()
    {
        var productFields = _productFieldRepository.GetAll(x => !x.IsDeleted);
        return productFields.Select(pf => _mapper.Map<ProductFieldDTO>(pf));
    }

    public IQueryable<ProductFieldDTO> GetAllActive()
    {
        var productFields = _productFieldRepository.GetAllActive(x => true);
        return productFields.Select(pf => _mapper.Map<ProductFieldDTO>(pf));
    }

    public IQueryable<ProductFieldDTO> GetAllDeleted()
    {
        var productFields = _productFieldRepository.GetAllDeleted(x => true);
        return productFields.Select(pf => _mapper.Map<ProductFieldDTO>(pf));
    }

    public ProductFieldDTO GetById(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<ProductFieldDTO>(productField);
    }

    public async Task RemoveAsync(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productFieldRepository.RemoveAsync(productField);
    }

    public async Task<ProductFieldDTO> UpdateAsync(int id, UpdateProductFieldDTO dto)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        var product = _productRepository.GetById(x => x.Id == dto.ProductId && !x.IsDeleted);
        var updatedProductField = _mapper.Map(dto, productField);
        var result = await _productFieldRepository.UpdateAsync(updatedProductField);
        return _mapper.Map<ProductFieldDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productFieldRepository.SoftDeleteAsync(productField);
    }

    public async Task RecoverAsync(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _productFieldRepository.RecoverAsync(productField);
    }

    public async Task ActivateAsync(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productFieldRepository.ActivateAsync(productField);
    }

    public async Task DeactivateAsync(int id)
    {
        var productField = _productFieldRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _productFieldRepository.DeactivateAsync(productField);
    }
}