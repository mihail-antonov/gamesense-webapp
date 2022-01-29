namespace gamesense_webapp.Data
{
    using gamesense_webapp.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre_Game>().HasKey(am => new
            {
                am.GenreId,
                am.GameId,
            }
            );
            builder.Entity<Genre_Game>().HasOne(g => g.Game).WithMany(gg => gg.Genre_Game).HasForeignKey(g => g.GameId);
            builder.Entity<Genre_Game>().HasOne(g => g.Genre).WithMany(gg => gg.Genre_Game).HasForeignKey(g => g.GenreId);
            base.OnModelCreating(builder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre_Game> Genres_Games { get; set; }
    }
}
