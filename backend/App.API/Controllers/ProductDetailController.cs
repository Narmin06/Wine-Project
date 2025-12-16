using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.ProductDetailDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetailController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public ActionResult<IQueryable<ProductDetailDTO>> GetAll()
    {
        var productDetails = _productDetailService.GetAll();
        return Ok(productDetails);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<ProductDetailDTO>> GetAllActive()
    {
        var productDetails = _productDetailService.GetAllActive();
        return Ok(productDetails);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<ProductDetailDTO>> GetAllDeleted()
    {
        var productDetails = _productDetailService.GetAllDeleted();
        return Ok(productDetails);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDetailDTO> GetById(int id)
    {
        var productDetail = _productDetailService.GetById(id);
        return Ok(productDetail);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDetailDTO>> Create([FromBody] CreateProductDetailDTO dto)
    {
        var productDetail = await _productDetailService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = productDetail.Id }, productDetail);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDetailDTO>> Update(int id, [FromBody] UpdateProductDetailDTO dto)
    {
        var productDetail = await _productDetailService.UpdateAsync(id, dto);
        return Ok(productDetail);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productDetailService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _productDetailService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _productDetailService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _productDetailService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _productDetailService.DeactivateAsync(id);
        return NoContent();
    }
}