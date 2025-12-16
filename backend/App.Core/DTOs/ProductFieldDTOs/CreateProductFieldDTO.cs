namespace App.Core.DTOs.ProductFieldDTOs;

public record class CreateProductFieldDTO(
    string Key,
    string Value,
    int ProductId
);