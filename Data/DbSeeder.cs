using Microsoft.AspNetCore.Identity;
using projetNet.Constants;
using projetNet.Models;

namespace projetNet.Data;

public static class DbSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = Roles.All;

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var admins = new List<(string Email, string Password, string FirstName, string LastName)>
        {
            ("yasserchouket0102@gmail.com", "Admin@123", "Yasser", "Chouket"),
        };

        foreach (var (email, password, firstName, lastName) in admins)
        {
            var adminUser = await userManager.FindByEmailAsync(email);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsEmailVerified = true,
                    IsPhoneVerified = true
                };

                var result = await userManager.CreateAsync(adminUser, password);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin);
                }
            }
        }
    }
}
