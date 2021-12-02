using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenders.Api.Formatters;
using Tenders.Api.Services;
using Tenders.Api.Validators;

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

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICitizenService, CitizenService>();
            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
            services.AddValidatorsFromAssemblyContaining(typeof(CitizenRequestDtoValidator));


        }
    }
}