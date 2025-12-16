using App.Core.DTOs.Commons;

namespace App.Core.DTOs.SubCategoryDTOs;

public class SubCategoryDTO : BaseEntityDTO
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}