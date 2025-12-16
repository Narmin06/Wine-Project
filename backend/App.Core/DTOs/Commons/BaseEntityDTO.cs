namespace App.Core.DTOs.Commons;

public class BaseEntityDTO
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
