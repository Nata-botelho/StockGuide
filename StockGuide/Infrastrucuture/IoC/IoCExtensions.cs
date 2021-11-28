using Microsoft.Extensions.DependencyInjection;
using StockGuide.Services;
using StockGuide.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockGuide.Infrastrucuture.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<StockCalculator>();

            return services;
        }
    }
}
