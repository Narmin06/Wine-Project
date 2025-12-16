using App.Core.DTOs.Commons;

namespace App.Core.DTOs.SettingDTOs;

public class SettingDTO : BaseEntityDTO
{
    public string Phone { get; set; }
    public string Location { get; set; }
    public string IconUrl { get; set; }
}
