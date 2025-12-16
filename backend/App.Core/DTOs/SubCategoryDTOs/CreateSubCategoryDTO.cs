namespace App.Core.DTOs.SubCategoryDTOs;

public record class CreateSubCategoryDTO(
    string Name,
    int CategoryId
);