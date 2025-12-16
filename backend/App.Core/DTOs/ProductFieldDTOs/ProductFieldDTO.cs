using App.Core.DTOs.Commons;

namespace App.Core.DTOs.ProductFieldDTOs;

public class ProductFieldDTO : BaseEntityDTO
{
    public string Key { get; set; }
    public string Value { get; set; }
    public int ProductId { get; set; }
    public string ProductTitle { get; set; }
}