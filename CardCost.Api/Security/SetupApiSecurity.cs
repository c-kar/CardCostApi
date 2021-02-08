using CardCost.Api.Options.Bearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CardCost.Api.Security
{
    public static class SetupApiSecurity
    {
        public static IServiceCollection AddBearerAuth(this IServiceCollection services, IConfiguration _configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("BearerOptions");
            services.Configure<BearerOptions>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<BearerOptions>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            return services;
        }
    }
}
