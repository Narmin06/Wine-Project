namespace App.Core.DTOs.ProductFieldDTOs;

public record class UpdateProductFieldDTO(
    string Key,
    string Value,
    int ProductId
) : CreateProductFieldDTO(Key, Value, ProductId);