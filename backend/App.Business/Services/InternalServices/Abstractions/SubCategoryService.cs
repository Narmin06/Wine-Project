using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SubCategoryDTOs;
using App.Core.Entities.Relations;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class SubCategoryService : ISubCategoryService
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public SubCategoryService(
        ISubCategoryRepository subCategoryRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<SubCategoryDTO> AddAsync(CreateSubCategoryDTO dto)
    {
        var category = _categoryRepository.GetById(x => x.Id == dto.CategoryId && !x.IsDeleted);
        var subCategory = _mapper.Map<SubCategory>(dto);
        var addedSubCategory = await _subCategoryRepository.AddAsync(subCategory);
        return _mapper.Map<SubCategoryDTO>(addedSubCategory);
    }

    public IQueryable<SubCategoryDTO> GetAll()
    {
        var subCategories = _subCategoryRepository.GetAll(x => !x.IsDeleted);
        return subCategories.Select(sc => _mapper.Map<SubCategoryDTO>(sc));
    }

    public IQueryable<SubCategoryDTO> GetAllActive()
    {
        var subCategories = _subCategoryRepository.GetAllActive(x => true);
        return subCategories.Select(sc => _mapper.Map<SubCategoryDTO>(sc));
    }

    public IQueryable<SubCategoryDTO> GetAllDeleted()
    {
        var subCategories = _subCategoryRepository.GetAllDeleted(x => true);
        return subCategories.Select(sc => _mapper.Map<SubCategoryDTO>(sc));
    }

    public SubCategoryDTO GetById(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<SubCategoryDTO>(subCategory);
    }

    public async Task RemoveAsync(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _subCategoryRepository.RemoveAsync(subCategory);
    }

    public async Task<SubCategoryDTO> UpdateAsync(int id, UpdateSubCategoryDTO dto)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        var category = _categoryRepository.GetById(x => x.Id == dto.CategoryId && !x.IsDeleted);
        var updatedSubCategory = _mapper.Map(dto, subCategory);
        var result = await _subCategoryRepository.UpdateAsync(updatedSubCategory);
        return _mapper.Map<SubCategoryDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _subCategoryRepository.SoftDeleteAsync(subCategory);
    }

    public async Task RecoverAsync(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _subCategoryRepository.RecoverAsync(subCategory);
    }

    public async Task ActivateAsync(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _subCategoryRepository.ActivateAsync(subCategory);
    }

    public async Task DeactivateAsync(int id)
    {
        var subCategory = _subCategoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _subCategoryRepository.DeactivateAsync(subCategory);
    }
}