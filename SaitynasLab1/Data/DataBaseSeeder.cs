using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SaitynasLab1.Auth.Model;
using SaitynasLab1.Data.Dtos.Auth;

namespace SaitynasLab1.Data
{
    public class DataBaseSeeder
    {
        private readonly UserManager<SaitynasUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataBaseSeeder(UserManager<SaitynasUser>userManager, RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            foreach (var role in SaitynasUserRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var newAdminUser = new SaitynasUser
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "VerySafePassword1!");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, SaitynasUserRoles.All);
                }
            }


        }
    }
}
