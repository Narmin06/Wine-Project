using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductFieldDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductFieldController : ControllerBase
{
    private readonly IProductFieldService _productFieldService;

    public ProductFieldController(IProductFieldService productFieldService)
    {
        _productFieldService = productFieldService;
    }

    [HttpGet]
    public ActionResult<IQueryable<ProductFieldDTO>> GetAll()
    {
        var productFields = _productFieldService.GetAll();
        return Ok(productFields);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<ProductFieldDTO>> GetAllActive()
    {
        var productFields = _productFieldService.GetAllActive();
        return Ok(productFields);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<ProductFieldDTO>> GetAllDeleted()
    {
        var productFields = _productFieldService.GetAllDeleted();
        return Ok(productFields);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductFieldDTO> GetById(int id)
    {
        var productField = _productFieldService.GetById(id);
        return Ok(productField);
    }

    [HttpPost]
    public async Task<ActionResult<ProductFieldDTO>> Create([FromBody] CreateProductFieldDTO dto)
    {
        var productField = await _productFieldService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = productField.Id }, productField);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductFieldDTO>> Update(int id, [FromBody] UpdateProductFieldDTO dto)
    {
        var productField = await _productFieldService.UpdateAsync(id, dto);
        return Ok(productField);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productFieldService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _productFieldService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _productFieldService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _productFieldService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _productFieldService.DeactivateAsync(id);
        return NoContent();
    }
}