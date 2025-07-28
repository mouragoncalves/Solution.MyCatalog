using Microsoft.EntityFrameworkCore;
using MyCatalog.Api.Data;

namespace MyCatalog.Api.Configurations
{
    public static class ApiDbContextConfiguration
    {
        public static WebApplicationBuilder AddApiDbContextConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApiDbContext>(o =>
                o.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception(""))
            );

            return builder;
        }
    }
}
