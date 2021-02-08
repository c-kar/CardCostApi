using CardCost.Core.Repositories;
using CardCost.Infrastructure.Repositories;
using CardCost.Infrastructure.Repositories.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace CardCost.Infrastructure
{
    public static class SetupDependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<ICardCostRepository, CardCostRepository>();
            services.AddTransient<ICCMatrixRepository, CCMatrixRepository>();
            services.AddTransient<IAccessUserRepository, AccessUserRepository>();

            //Mock repositories for testing purposes

            //services.AddTransient<ICardCostRepository, CardCostMockRepository>();
            //services.AddTransient<ICCMatrixRepository, CCMatrixMockRepository>();
            return services;
        }
    }
}
