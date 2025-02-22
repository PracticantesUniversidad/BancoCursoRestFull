﻿using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //seed default AdminUser
            var defaultUser = new ApplicationUser
            {
                UserName = "userAdmin",
                Email = "userAdmin@mail.com",
                Nombre = "JuanNombre",
                Apellido = "JuanApellido",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All( u => u.Id != defaultUser.Id) ) 
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "1234Pa$wordAdin");
                    await userManager.AddToRoleAsync(defaultUser, roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, roles.Basic.ToString());

                }
            }

        }
    }
}

