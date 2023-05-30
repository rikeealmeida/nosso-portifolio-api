using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Job>()
            //    .HasOne(j => j.Author)
            //    .WithMany(u => u.Jobs)
            //    .HasForeignKey(j => j.AuthorId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id);
        }

        public DbSet<nosso_portifolio_api.Models.User> User { get; set; } = default!;
        public DbSet<nosso_portifolio_api.Models.Project> Project { get; set; } = default!;

    }
}

