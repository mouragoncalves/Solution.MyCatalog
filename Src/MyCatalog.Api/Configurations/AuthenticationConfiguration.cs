using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyCatalog.Api.Models;

namespace MyCatalog.Api.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static WebApplicationBuilder AddAuthenticationConfiguration(this WebApplicationBuilder builder)
        {
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(jwtSettings);

            var jwtOptions = jwtSettings.Get<JwtSettings>() ?? throw new Exception("JWT settings are not configured properly.");

            var key = System.Text.Encoding.ASCII.GetBytes(jwtOptions.Segredo);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Emissor,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions.ValidoEm,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero // Remove a tolerância de tempo padrão de 5 minutos
                    };
                });

            return builder;
        }
    }
}
