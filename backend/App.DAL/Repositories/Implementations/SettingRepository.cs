using App.Core.Entities;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class SettingRepository : Repository<Setting>, ISettingRepository
{
	public SettingRepository(AppDbContext context) : base(context) { }
}
