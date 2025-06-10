using AuthService.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthService v1"));
}

app.UseAuthorization();
app.MapControllers();

app.Run();