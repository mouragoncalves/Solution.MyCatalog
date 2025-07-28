using MyCatalog.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddControllerConfiguration()
    .AddCorsConfiguration()
    .AddEndpointsConfiguration()
    .AddSwaggerGenConfiguration()
    .AddApiDbContextConfiguration()
    .AddIdentityConfiguration()
    .AddAuthenticationConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/", () => "Welcome to MyCatalog API!");

app.Run();
