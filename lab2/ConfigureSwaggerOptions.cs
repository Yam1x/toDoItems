using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace lab2
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {

        public void Configure(SwaggerGenOptions options)
        {
            var apiVersion = "1.0";
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = apiVersion,
                    Title = $"ToDo API {apiVersion}",
                });
        }
    }
}