using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Api.Options.Swagger
{
    public static class AppBuilderExtensions
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Get Ip Details",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "ckarou@hotmail.com",
                    },
                });
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder builder, IConfiguration config)
        {
            var swaggerOptions = config.GetSection(SwaggerOptions.SwaggerConfigKey).Get<SwaggerOptions>();

            //
            builder.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.Route;
            });

            //
            builder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            return builder;
        }
    }
}
