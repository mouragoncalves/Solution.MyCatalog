namespace MyCatalog.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static WebApplicationBuilder AddCorsConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(o =>
            {
                o.AddPolicy("Development", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                o.AddPolicy("Production", builder =>
                    builder.WithOrigins("https://localhost:8080")
                    .WithMethods("POST")
                    .AllowAnyHeader());
            });

            return builder;
        }
    }
}
