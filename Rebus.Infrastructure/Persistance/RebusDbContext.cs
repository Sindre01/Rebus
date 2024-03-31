using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;

namespace Rebus.Infrastructure.Persistance;
internal class RebusDbContext(DbContextOptions<RebusDbContext> options) : DbContext(options)
{
    internal DbSet<User> Users { get; set; } 
    internal DbSet<UserGameHistory> UserGameHistories { get; set; }
    internal DbSet<Role> Roles { get; set; }
    internal DbSet<GameUserAccess> GameUserAccesses { get; set; }
    internal DbSet<GameAccessCode> GameAccessCodes { get; set; }
    internal DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Object inside visual studio
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
              .OwnsOne(r => r.Location);

        //relations:
        /*   modelBuilder.Entity<Game>()
       .HasOne(g => g.GameAccessCode)
       .WithOne(ac => ac.Game)
       .HasForeignKey<GameAccessCode>(ac => ac.GameId);

           modelBuilder.Entity<GameUserAccess>()
               .HasOne(gua => gua.User)
               .WithMany(u => u.GameUserAccesses)
               .HasForeignKey(gua => gua.UserId);

           modelBuilder.Entity<GameUserAccess>()
               .HasOne(gua => gua.GameAccessCode)
               .WithMany(ac => ac.GameUserAccesses)
               .HasForeignKey(gua => gua.GameAccessCodeId);
           */

        modelBuilder.Entity<Game>()
            .HasOne(g => g.GameAccessCode)
            .WithOne(gac => gac.Game)
            .HasForeignKey<GameAccessCode>(gac => gac.GameId) // ("GameId) Shadow key
            .IsRequired(); //each AccessCode must have a related Game,

        modelBuilder.Entity<GameAccessCode>()
            .HasMany(gac => gac.GameUserAccesses)
            .WithOne(gua => gua.GameAccessCode)
            .HasForeignKey(gua => gua.GameAccessCodeId) // ("GameAccesCodeId") Shadow key
            .IsRequired();  //each GameUserAccess must have a related GameAccessCode,

        modelBuilder.Entity<User>()
            .HasMany(u => u.GameUserAccesses)
            .WithOne(ua => ua.User)
            .HasForeignKey(ua => ua.UserId) // ("UserId") Shadow key
            .IsRequired();  //each GameUserAccess must have a related User,




        /*    modelBuilder.Entity<User>()
                .HasMany(u => u.UserGameHistories)
                .WithOne(ugh => ugh.User)
                .HasForeignKey(ugh => ugh.UserId) // ("UserId) Shadow key
                .IsRequired();  //each UserGameHistory must have a related User

            modelBuilder.Entity<User>()
                 .HasMany(u => u.GameCreators)
                 .WithOne(gc => gc.User)
                 .HasForeignKey(gc => gc.UserId) // ("UserId) Shadow key
                 .IsRequired();  //each GameCreator must have a related User

                modelBuilder.Entity<Role>()
                .HasMany(r => r.GameCreators)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId) // ("RoleId) Shadow key
                .IsRequired();  //each GameCreator must have a related Role

                modelBuilder.Entity<Game>()
            .HasMany(g => g.UserGameHistories)
            .WithOne(ugh => ugh.Game)
            .HasForeignKey(ugh => ugh.GameId)
            .IsRequired(); //each UserGameHistory must have a related game 
        
                modelBuilder.Entity<Game>()
             .HasMany(g => g.GameCreators)
             .WithOne(gc => gc.Game)
             .HasForeignKey(gc => gc.GameId) // ("GameId) Shadow key
             .IsRequired();  //each GameCreator must have a related User


         */






        //...more tables to be added
    }

}

