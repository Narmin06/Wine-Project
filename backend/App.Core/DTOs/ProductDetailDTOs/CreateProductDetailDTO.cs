namespace App.Core.DTOs.ProductDetailDTOs;

public record class CreateProductDetailDTO(
    string Title,
    string Description,
    int ProductId
);