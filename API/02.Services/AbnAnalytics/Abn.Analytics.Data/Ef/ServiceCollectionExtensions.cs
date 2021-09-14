using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Data.Ef
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServer<TDbContext>(this IServiceCollection services,
            string connectionString, string migrationAssembly) where TDbContext : DbContext
        {
            services.AddDbContext<DbContext, TDbContext>(x => {
                x.UseSqlServer(connectionString, z => z.MigrationsAssembly(migrationAssembly) );
            }
                      , ServiceLifetime.Scoped
                 )
                 ;

            services.AddScoped<TDbContext>();
            return services;
        }


    }
}
