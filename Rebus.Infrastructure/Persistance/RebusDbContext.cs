using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;

namespace Rebus.Infrastructure.Persistance;
internal class RebusDbContext : DbContext
{
    internal DbSet<User> Users { get; set; } 
    internal DbSet<Location> Location { get; set; }
    internal DbSet<UserRole> UserRoles { get; set; }
    internal DbSet<Role> Roles { get; set; }
    internal DbSet<Role> UserAccess { get; set; }
    internal DbSet<Role> AccessCode { get; set; }
    internal DbSet<Role> Game { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RebusDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Object inside visual studio
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>()
        //      .OwnsOne(r => r.Location);

        //relations:

        modelBuilder.Entity<User>()
            .HasOne(u => u.Location)
            .WithMany()
            .HasForeignKey(l => l.UserId);
    }

}

