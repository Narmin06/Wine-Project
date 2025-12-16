using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.CategoryDTOs;
using App.Core.Entities.Relations;
using App.Core.Exceptions.Commons;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDTO> AddAsync(CreateCategoryDTO dto)
    {
        var category = _mapper.Map<Category>(dto);
        var addedCategory = await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryDTO>(addedCategory);
    }

    public IQueryable<CategoryDTO> GetAll()
    {
        var categories = _categoryRepository.GetAll(x => !x.IsDeleted);
        return categories.Select(c => _mapper.Map<CategoryDTO>(c));
    }

    public IQueryable<CategoryDTO> GetAllActive()
    {
        var categories = _categoryRepository.GetAllActive(x => true);
        return categories.Select(c => _mapper.Map<CategoryDTO>(c));
    }

    public IQueryable<CategoryDTO> GetAllDeleted()
    {
        var categories = _categoryRepository.GetAllDeleted(x => true);
        return categories.Select(c => _mapper.Map<CategoryDTO>(c));
    }

    public CategoryDTO GetById(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task RemoveAsync(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _categoryRepository.RemoveAsync(category);
    }

    public async Task<CategoryDTO> UpdateAsync(int id, UpdateCategoryDTO dto)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        var updatedCategory = _mapper.Map(dto, category);
        var result = await _categoryRepository.UpdateAsync(updatedCategory);
        return _mapper.Map<CategoryDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _categoryRepository.SoftDeleteAsync(category);
    }

    public async Task RecoverAsync(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _categoryRepository.RecoverAsync(category);
    }

    public async Task ActivateAsync(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _categoryRepository.ActivateAsync(category);
    }

    public async Task DeactivateAsync(int id)
    {
        var category = _categoryRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _categoryRepository.DeactivateAsync(category);
    }
}