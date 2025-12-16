using App.Core.DTOs.Commons;
using Microsoft.AspNetCore.Http;

namespace App.Core.DTOs.ProductDTOs;

public class CreateProductDTO : IAuditedImageEntityDTO, IAuditedIconEntityDTO
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }
    public float Liter { get; set; }
    public DateTime ProdDate { get; set; }
    public string Location { get; set; }
    public IFormFile Icon { get; set; }
}