using Microsoft.AspNetCore.Identity;
using MyCatalog.Api.Data;

namespace MyCatalog.Api.Configurations
{
    public static class IdentityConfiguration
    {
        public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>();
                //.AddDefaultTokenProviders();

            return builder;
        }
    }
}
