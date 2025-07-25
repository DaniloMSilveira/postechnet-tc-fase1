using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCG.Infra.Security.Constants;
using FCG.Infra.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace FCG.Infra.Security.Seeds
{
    public static class IdentitySeed
    {
        public static async Task SeedData(UserManager<IdentityCustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Roles.ObterListaRoles())
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var nome = "Administrador";
            var email = "admin@fcg.com";
            var senha = "Admin123!";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityCustomUser
                {
                    Nome = nome,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, senha);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.USUARIO);
                    await userManager.AddToRoleAsync(user, Roles.ADMINISTRADOR);
                }
            }
        }
    }
}