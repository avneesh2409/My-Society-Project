using Microsoft.EntityFrameworkCore;
using mysocietywebsite.Model.Entities;
using System;

namespace mysocietywebsite.Model.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                Guid adminRoleId = Guid.NewGuid();
                modelBuilder.Entity<Role>().HasData(new Role
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    IsActive = true,
                    CreatedBy = adminRoleId,
                    ModifiedBy = adminRoleId,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                    ModifiedOn = DateTime.UtcNow
                });
            Guid adminId = Guid.NewGuid();
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = adminId,
                    Username = "AD",
                    Fullname = "Tarunendra",
                    Email = "tarun@gmail.com",
                    RoleId = adminRoleId,
                    Contact = "9109072549",
                    Address = "H.No - 30 Indus Town",
                    Password = "123456789",
                    IsActive = true,
                    CreatedBy = adminId,
                    ModifiedBy = adminId,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                    ModifiedOn = DateTime.UtcNow
                });
            
            }
    }
}
