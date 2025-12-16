using App.Core.Entities;
using App.Core.Entities.Identity;
using App.Core.Enums;
using App.DAL.Repositories.Implementations;
using App.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Presistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedDatabaseAsync(AppDbContext context, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, ISettingRepository settingRepository)
        {
            foreach (var role in Enum.GetValues(typeof(EUserRole)).Cast<EUserRole>().Select(x => x.ToString()))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminExists = await userManager.FindByNameAsync("admin");

            if (adminExists == null)
            {
                var userAdmin = new User { UserName = "admin", Email = "admin@admin.az", EmailConfirmed = true };
                await userManager.CreateAsync(userAdmin, "!Admin123.?");
                await userManager.AddToRoleAsync(userAdmin, EUserRole.Admin.ToString());
            }


            var settingExists = settingRepository.GetAll(x => true);

            if (!settingExists.Any())
            {
                var setting = new Setting
                {
                    Phone = "+994501234567",
                    Email = "info@lukslab.az",
                    Location = "Bakı, Nəsimi rayonu, Heydər Əliyev prospekti 1",
                    IconUrl = "/images/settings/icon.png"
                };

                await settingRepository.AddAsync(setting);
            }

            await context.SaveChangesAsync();
        }
    }
}
