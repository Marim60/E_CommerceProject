using E_CommerceProject.Constants;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace E_CommerceProject.Data
{
    public class DbRole
    {
        public static async Task RoleDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            //adding some roles to db
            await roleMgr.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Role.User.ToString()));

            // create admin user

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Role.Admin.ToString());
            }



        }

    }
}
