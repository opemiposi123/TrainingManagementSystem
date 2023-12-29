using ITHelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using TrainingManagementService.Entities;
using static ITHelpDesk.Domain.Entities.IdentityCustom;

namespace Persistence.Context;

public static class DbSeederInitializer
{
    public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
    {
        string[] roleNames = { Roles.SystemAdmin.ToString(), Roles.LineManager.ToString(), Roles.SystemUser.ToString() };

        var roles = new List<Role>()
        {
            new() {
                Name = roleNames[0],
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "SYSTEM"
            },

            new() {
                Name = roleNames[1],
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "SYSTEM"
            },

            new() {
                Name = roleNames[2],
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "SYSTEM"
            }
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }
    }

    public static async Task SeedUsersAsync(UserManager<Employee> userManager)
    {
        var usersAndRoles = new Dictionary<Employee, List<string>>
        {
            {
                new Employee
                {
                    UserName = "MahmoodAhmad",
                    Email = "md@gmail.com",
                    PhoneNumber = "09165353829",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "SYSTEM",
                    DisplayName = "Mahmood",
                    FirstName = "Mahmood",
                    LastName = "Ahmad"
                },
                new List<string> { Roles.SystemAdmin.ToString(), Roles.LineManager.ToString(), Roles.SystemUser.ToString() }
            },

            {
                new Employee
                {
                    UserName = "Tohir",
                    Email = "tboy@gmail.com",
                    PhoneNumber = "4414773773",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "SYSTEM",
                    DisplayName = "tboy",
                    FirstName = "Tahir",
                    LastName = "Ahmad"
                },
                new List<string> { Roles.LineManager.ToString(), Roles.SystemUser.ToString() }
            }
        };

        foreach (var userAndRoles in usersAndRoles)
        {
            var user = userAndRoles.Key;
            var userRoles = userAndRoles.Value;

            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "Mahmood12#");
                await userManager.AddToRolesAsync(user, userRoles);
            }
        }
    }
}
