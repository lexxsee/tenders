using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tenders.Api.Helpers
{
    public static class StartupHelpers
    {
        public static void AddDbContexts<TTenderDbContext>(
            this IServiceCollection services, IConfiguration configuration)
            where TTenderDbContext : DbContext
        {
            var connectionString = configuration.GetConnectionString("TenderConnectionString");

            services.AddDbContext<TTenderDbContext>(options =>
                options.UseSqlServer(connectionString,
                    sql => { sql.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null!); }
                ));
        }
    }
}