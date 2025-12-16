using App.Core.DTOs.Commons;
using Microsoft.AspNetCore.Http;

namespace App.Core.DTOs.SlideDTOs;

public class UpdateSlideDTO : IAuditedImageEntityDTO
{
    public IFormFile Image { get; set; }
}