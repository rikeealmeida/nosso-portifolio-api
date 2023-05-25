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
        public DbSet<nosso_portifolio_api.Models.User> User { get; set; } = default!;

    }
}

