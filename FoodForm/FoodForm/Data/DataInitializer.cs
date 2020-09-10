using FoodForm.Models;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForm.Data
{
    /// <summary>
    /// Class utilizada na inicialização e seeding dos utilizadores e roles base da aplicação
    /// </summary>
    public static class DataInitializer
    {

        /// <summary>
        /// Seeding de ambos os users e roles default
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        /// <summary>
        /// Método utilizado para fazer o seeding do moderador base
        /// </summary>
        /// <param name="userManager"></param>
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            
            if (userManager.FindByNameAsync("moderador@mail.com").Result == null)
            {
                ApplicationUser mod = new ApplicationUser();
                mod.UserName = "moderador@mail.com";
                mod.Email = "moderador@mail.com";
                mod.Timestamp = DateTime.Now;
                mod.EmailConfirmed = true;

                
                IdentityResult result = userManager.CreateAsync(mod, "Moderador123_").Result;

                if (result.Succeeded)
                {
                    //associa o role
                    userManager.AddToRoleAsync(mod, "Moderador").Wait();
                }
            }
        }

        /// <summary>
        /// Método utilizado para fazer o seeding dos roles base
        /// </summary>
        /// <param name="roleManager"></param>
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Utilizador").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Utilizador";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Moderador";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
