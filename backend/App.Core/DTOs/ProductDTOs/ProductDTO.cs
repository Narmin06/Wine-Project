using App.Core.DTOs.Commons;

namespace App.Core.DTOs.ProductDTOs;

public class ProductDTO : BaseEntityDTO
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public float Liter { get; set; }
    public DateTime ProdDate { get; set; }
    public string Location { get; set; }
    public string CompanyIconUrl { get; set; }
}