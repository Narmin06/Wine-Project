using App.Core.Entities.Commons;

namespace App.Core.Entities;

public class Setting : AuditableEntity
{
	public string Phone { get; set; }
	public string Location { get; set; }
	public string IconUrl { get; set; }
	public string Email { get; set; }
}
