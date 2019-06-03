using CHUSHKA.Models;
using CHUSHKA.WEB.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CHUSHKA.WEB.Utilities
{
    public class Seeder
    {
        public static async Task Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRole);

            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdministratorRole));
            }

            var configuration = provider.GetRequiredService<IConfiguration>();
            var userManager = provider.GetRequiredService<UserManager<ChushkaUser>>();
            CreatePowerUser(configuration, userManager).Wait();
        }

        private static async Task CreatePowerUser(IConfiguration configuration, UserManager<ChushkaUser> userManager)
        {
            var powerUser = new ChushkaUser
            {
                UserName = configuration.GetSection("UserSettings")["Username"],
                Email = configuration.GetSection("UserSettings")["UserEmail"]
            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];

            var user = await userManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);
           
            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Administrator" role 
                    await userManager.AddToRoleAsync(powerUser, GlobalConstants.AdministratorRole);
                }
            }
        }
    }
}