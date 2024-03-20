using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Application;
using Asp.Versioning.ApiExplorer;
using Persistence;
using Application.Common.Mappings;
using System.Reflection;
using lab2;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(Application.Interfaces.IToDoDbContext).Assembly));
});

builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });

});

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddRazorPages();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.InjectStylesheet("SwaggerDark.css");
        config.SwaggerEndpoint(
                $"/swagger/v1/swagger.json","V1");
        config.RoutePrefix = string.Empty;
    });

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
