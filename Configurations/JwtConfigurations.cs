using System.Text;
using API_Desafio_Angular.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API_Desafio_Angular.Configurations
{ 
    public static class JwtConfiguration
    {
        public static void ConfigureJwtToken(this IServiceCollection services, IConfiguration Configuration)
        {
            var settingsSection = Configuration.GetSection("AppSettings");
            services.Configure<TokenSettings>(settingsSection);

            var tokenSettings = settingsSection.Get<TokenSettings>();
            var key = Encoding.ASCII.GetBytes(tokenSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new TokenService(tokenSettings));
        }
    }
}

