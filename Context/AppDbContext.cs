using System;
using Microsoft.EntityFrameworkCore;

namespace nosso_portifolio_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}

