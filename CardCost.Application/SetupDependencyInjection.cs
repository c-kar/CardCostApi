using CardCost.Application.Interfaces;
using CardCost.Application.Services;
using CardCost.Infrastructure.Interfaces;
using CardCost.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CardCost.Application
{
    public static class SetupDependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<ICardCostService, CardCostService>()
                .AddTransient<IBinListClient, BinListClient>()
                .AddTransient<ICCMatrixService, CCMatrixService>()
                .AddTransient<IAccessUserService, AccessUserService>();

            return services;
        }
    }
}
