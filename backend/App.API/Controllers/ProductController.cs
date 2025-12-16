using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IQueryable<ProductDTO>> GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<ProductDTO>> GetAllActive()
    {
        var products = _productService.GetAllActive();
        return Ok(products);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<ProductDTO>> GetAllDeleted()
    {
        var products = _productService.GetAllDeleted();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        var product = _productService.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Create([FromForm] CreateProductDTO dto)
    {
        var product = await _productService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDTO>> Update(int id, [FromForm] UpdateProductDTO dto)
    {
        var product = await _productService.UpdateAsync(id, dto);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _productService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _productService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _productService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _productService.DeactivateAsync(id);
        return NoContent();
    }
}