using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SubCategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    [HttpGet]
    public ActionResult<IQueryable<SubCategoryDTO>> GetAll()
    {
        var subCategories = _subCategoryService.GetAll();
        return Ok(subCategories);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<SubCategoryDTO>> GetAllActive()
    {
        var subCategories = _subCategoryService.GetAllActive();
        return Ok(subCategories);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<SubCategoryDTO>> GetAllDeleted()
    {
        var subCategories = _subCategoryService.GetAllDeleted();
        return Ok(subCategories);
    }

    [HttpGet("{id}")]
    public ActionResult<SubCategoryDTO> GetById(int id)
    {
        var subCategory = _subCategoryService.GetById(id);
        return Ok(subCategory);
    }

    [HttpPost]
    public async Task<ActionResult<SubCategoryDTO>> Create([FromBody] CreateSubCategoryDTO dto)
    {
        var subCategory = await _subCategoryService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = subCategory.Id }, subCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SubCategoryDTO>> Update(int id, [FromBody] UpdateSubCategoryDTO dto)
    {
        var subCategory = await _subCategoryService.UpdateAsync(id, dto);
        return Ok(subCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _subCategoryService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _subCategoryService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _subCategoryService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _subCategoryService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _subCategoryService.DeactivateAsync(id);
        return NoContent();
    }
}