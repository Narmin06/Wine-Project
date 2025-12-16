using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public ActionResult<IQueryable<CategoryDTO>> GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<CategoryDTO>> GetAllActive()
    {
        var categories = _categoryService.GetAllActive();
        return Ok(categories);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<CategoryDTO>> GetAllDeleted()
    {
        var categories = _categoryService.GetAllDeleted();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public ActionResult<CategoryDTO> GetById(int id)
    {
        var category = _categoryService.GetById(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create([FromBody] CreateCategoryDTO dto)
    {
        var category = await _categoryService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDTO>> Update(int id, [FromBody] UpdateCategoryDTO dto)
    {
        var category = await _categoryService.UpdateAsync(id, dto);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _categoryService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _categoryService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _categoryService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _categoryService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _categoryService.DeactivateAsync(id);
        return NoContent();
    }
}