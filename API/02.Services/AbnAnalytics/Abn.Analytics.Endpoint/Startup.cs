
using Abn.Analytics.Endpoint.Grpc.services;
using Abn.Framework.Core.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Abn.Analytics.ApplicationContract;
using Abn.Analytics.Application;
using Abn.Analytics.Endpoint.Grpc.Map;

using Abn.Analytics.Data.Repository;
using Abn.Framework.Core.Ef;
using Abn.Analytics.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Abn.Analytics.Domain.StatusObjectAggregate;
using Abn.Analytics.Application.AbnHub;
using Abn.Analytics.Endpoint.Configs;

namespace Abn.Analytics.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();

            services.AddSqlServer<CalculatorDbContext>(Configuration.GetConnectionString("db"), "Abn.Analytics.Endpoint");

            services.AddTransient<IStatusObjectRepository, StatusObjectRepository>();

            services.AddTransient<IDataCalculatorService, Application.DataCalculatorService >();
            services.AddAutoMapper(typeof(GrpcServiceProfile));
            services.AddControllers();
            services.AddSignalR();
     

            services.AddGrpc();
            services.AddGrpcReflection();
            services.AddQueue(Configuration);
            services.AddSingleton<ICommunicationHub, CommunicationHub>();
        }

  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            EnsureDatabasesCreated(app);
            app.UseRouting();
            app.UseCors("default");
            app.UseAuthorization();
            app.UseMiddleware<CorsMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<Abn.Analytics.Endpoint.Grpc.services.AnalyticsService>();
                endpoints.MapGrpcReflectionService();
                endpoints.MapHub<CommunicationHub>("/apphub");

            });
           
        }
        private void EnsureDatabasesCreated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CalculatorDbContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
