using App.Core.Entities.Identity;
using App.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Presistence
{
    public static class AutomatedMigration
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<AppDbContext>();

            if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();

            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var settingRepository = services.GetRequiredService<ISettingRepository>();

            await AppDbContextSeed.SeedDatabaseAsync(context, userManager, roleManager, settingRepository);
        }
    }
}
