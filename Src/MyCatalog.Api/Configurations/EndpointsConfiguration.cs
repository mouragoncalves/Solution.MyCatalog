namespace MyCatalog.Api.Configurations
{
    public static class EndpointsConfiguration
    {
        public static WebApplicationBuilder AddEndpointsConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }
    }
}
