using FundoBiblico.Dominio.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

public static class SeedRoles
{
    public static async Task CreateRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await CreateRole(roleManager, Roles.AdministrativoGeral);
        await CreateRole(roleManager, Roles.FundoBiblico);
        await CreateRole(roleManager, Roles.Financeiro);
        await CreateRole(roleManager, Roles.Dev);
    }

    private static async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}