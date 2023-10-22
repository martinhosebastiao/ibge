using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IBGE.Api.Presentation.Configurations.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerCustom(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Description = "Esta API usa autenticação e autorização. Example: \"Authorization: Bearer {token}\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            return services;
        }

        public static WebApplication UseSwaggerCustom(this WebApplication app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/docs/{documentName}/doc.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            }).UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = "docs";
                    options.DocumentTitle = " IBGE - Desafio .Net Core 7+";
                    options.EnableFilter();
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.List);
                    options.DefaultModelExpandDepth(0);

                    var descriptions = app.DescribeApiVersions();

                    // build a swagger endpoint for each discovered API version
                    foreach (var description in descriptions)
                    {
                        var url = $"/docs/{description.GroupName}/doc.json";
                        var name = description.GroupName.ToUpperInvariant();
                        options.SwaggerEndpoint(url, name);
                    }
                });

            return app;
        }
    }
}

