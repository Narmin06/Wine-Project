namespace App.Core.DTOs.ProductDetailDTOs;

public record class UpdateProductDetailDTO(
    string Title,
    string Description,
    int ProductId
);