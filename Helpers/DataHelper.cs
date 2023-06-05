using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;

namespace nosso_portifolio_api.Helpers
{
    public static class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider provider)
        {
            var dbContextService = provider.GetRequiredService<AppDbContext>();

            await dbContextService.Database.MigrateAsync();

        }
    }
}

