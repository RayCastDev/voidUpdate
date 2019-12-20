using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voidUpdate.Data.Models;

namespace voidUpdate.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task SeedSuperUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);

            var hasher = new PasswordHasher<ApplicationUser>();
            

            var user = new ApplicationUser
            {
                UserName = "RayCast",
                NormalizedUserName = "raycast",
                Email = "ivandem666@gmail.com",
                NormalizedEmail = "ivandem666@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hashedPassword = hasher.HashPassword(user, "admin");
            user.PasswordHash = hashedPassword;


            var isAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");

            if(!isAdminRole)
            {
                roleStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin"
                });
            }

            var hasSuperUser = _context.Users.Any(u => u.NormalizedUserName == user.UserName);

            if(!hasSuperUser)
            {
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, "Admin");
            }

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
