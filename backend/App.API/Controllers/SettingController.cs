using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SettingDTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SettingController : ControllerBase
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSettingAsync()
    {
        var settingDto = await _settingService.GetSettingAsync();
        return Ok(settingDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSettingAsync([FromBody] UpdateSettingDTO dto)
    {
        var updatedSettingDto = await _settingService.UpdateSettingAsync(dto);
        return Ok(updatedSettingDto);
    }
}
