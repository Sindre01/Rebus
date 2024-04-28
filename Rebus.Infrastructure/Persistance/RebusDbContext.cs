using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;

namespace Rebus.Infrastructure.Persistance;
internal class RebusDbContext(DbContextOptions<RebusDbContext> options)
     : IdentityDbContext<User>(options)
{
    internal DbSet<User> Users { get; set; } 
    internal DbSet<UserGameHistory> UserGameHistories { get; set; }
    internal DbSet<Role> Roles { get; set; }
    internal DbSet<UserGameAccess> UserGameAccesses { get; set; }
    internal DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Object inside visual studio
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
              .OwnsOne(r => r.Location);

        //relations:
        modelBuilder.Entity<Game>()
            .HasMany(g => g.UserGameAccesses)
            .WithOne(uga => uga.Game)
            .HasForeignKey(uga => uga.GameId) // ("GameAccesCodeId") Shadow key
            .IsRequired();  //each GameUserAccess must have a related GameAccessCode,

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserGameAccesses)
            .WithOne(uga => uga.User)
            .HasForeignKey(uga => uga.UserId) // ("UserId") Shadow key
            .IsRequired();  //each GameUserAccess must have a related User,

        //...more tables relations to be added
    }

}

