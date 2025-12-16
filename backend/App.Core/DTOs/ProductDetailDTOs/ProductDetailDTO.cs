using App.Core.DTOs.Commons;

namespace App.Core.DTOs.ProductDetailDTOs;

public class ProductDetailDTO : BaseEntityDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public string ProductTitle { get; set; }
}