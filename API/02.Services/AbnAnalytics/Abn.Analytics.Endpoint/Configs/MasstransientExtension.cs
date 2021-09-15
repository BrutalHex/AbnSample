using Abn.Analytics.Application.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abn.Analytics.Endpoint.Configs
{
    public static class MasstransitExtension
    {
        public static IServiceCollection AddQueue(this IServiceCollection services, IConfiguration configuration)
        {

            var appSettingsSection = configuration.GetSection("RabbitMq");
            var appSettings = appSettingsSection.Get<RabbitMqSetting>();
          
         
           
            services.AddMassTransit(x =>
            {

                x.AddConsumer<CalculatorConsumer>(cc =>
                {
                    

                });

                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.ExchangeType = ExchangeType.Direct;
          
                    cfg.Host(appSettings.HostName, appSettings.VirtualHost,
                    h =>
                    {
                        h.Username(appSettings.UserName);
                        h.Password(appSettings.Password);

                    });

                    cfg.UseHealthCheck(context);

                    cfg.ConfigureEndpoints(context);

                }));




            });
            services.AddMassTransitHostedService(true);
            return services;
        }
    }
}
