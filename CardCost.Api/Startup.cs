using AspNetCoreRateLimit;
using CardCost.Api.Middleware;
using CardCost.Api.Options.Swagger;
using CardCost.Api.Security;
using CardCost.Application;
using CardCost.Infrastructure;
using CardCost.Infrastructure.Data;
using CardCost.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CardCost.Api
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // Add Swagger
            services.AddSwaggerService();

            services.AddBearerAuth(_configuration);

            services.AddHttpClient();

            services.AddIpRateLimitMiddleware(_configuration);

            var connectionString = _configuration["ConnectionStrings:CardCostAppConnectionString"];

            services.AddDbContext<ICardCostDbContext, CardCostDbContext>(options => options.UseSqlServer(connectionString));

            services.AddHttpClient("binlist", c =>
            {
                c.BaseAddress = new Uri("https://lookup.binlist.net/");
            });

            // Add Application layer
            services.AddApplicationLayer();

            // Add Infrastructure layer
            services.AddInfrastructureLayer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.ConfigureSwagger(_configuration);

            app.UseRouting();

            app.UseAuthorization();

            app.UseIpRateLimiting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
