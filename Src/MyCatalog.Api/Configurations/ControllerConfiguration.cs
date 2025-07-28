namespace MyCatalog.Api.Configurations
{
    public static class ControllerConfiguration
    {
        public static WebApplicationBuilder AddControllerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            //.ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true); // Usado para fazer as validações de modelo manualmente

            return builder;
        }
    }
}
