using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SlideDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlideController : ControllerBase
{
    private readonly ISlideService _slideService;

    public SlideController(ISlideService slideService)
    {
        _slideService = slideService;
    }

    [HttpGet]
    public ActionResult<IQueryable<SlideDTO>> GetAll()
    {
        var slides = _slideService.GetAll();
        return Ok(slides);
    }

    [HttpGet("active")]
    public ActionResult<IQueryable<SlideDTO>> GetAllActive()
    {
        var slides = _slideService.GetAllActive();
        return Ok(slides);
    }

    [HttpGet("deleted")]
    public ActionResult<IQueryable<SlideDTO>> GetAllDeleted()
    {
        var slides = _slideService.GetAllDeleted();
        return Ok(slides);
    }

    [HttpGet("{id}")]
    public ActionResult<SlideDTO> GetById(int id)
    {
        var slide = _slideService.GetById(id);
        return Ok(slide);
    }

    [HttpPost]
    public async Task<ActionResult<SlideDTO>> Create([FromForm] CreateSlideDTO dto)
    {
        var slide = await _slideService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = slide.Id }, slide);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SlideDTO>> Update(int id, [FromForm] UpdateSlideDTO dto)
    {
        var slide = await _slideService.UpdateAsync(id, dto);
        return Ok(slide);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _slideService.RemoveAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/soft")]
    public async Task<ActionResult> SoftDelete(int id)
    {
        await _slideService.SoftDeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/recover")]
    public async Task<ActionResult> Recover(int id)
    {
        await _slideService.RecoverAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    public async Task<ActionResult> Activate(int id)
    {
        await _slideService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<ActionResult> Deactivate(int id)
    {
        await _slideService.DeactivateAsync(id);
        return NoContent();
    }
}