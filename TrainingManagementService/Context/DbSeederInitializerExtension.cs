using Microsoft.AspNetCore.Identity;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;
using static ITHelpDesk.Domain.Entities.IdentityCustom;

namespace Persistence.Context;

public static class DbSeederInitializerExtension
{
    public static async Task<IApplicationBuilder> UseItToSeedSqlServer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<TMSDbContext>();

            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return app;
            }

            var userManager = services.GetRequiredService<UserManager<Employee>>();
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            var repoManager = services.GetRequiredService<IRepositoryManager>();
            await DbSeederInitializer.SeedRolesAsync(roleManager);
            await DbSeederInitializer.SeedUsersAsync(userManager);
        }
        catch (Exception)
        {
            throw;
        }

        return app;
    }
}
