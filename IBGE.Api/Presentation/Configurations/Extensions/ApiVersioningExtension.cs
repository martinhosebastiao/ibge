using Asp.Versioning;

namespace IBGE.Api.Presentation.Configurations.Extensions
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddApiVersioningCustom(this IServiceCollection services)
        {
            services.AddApiVersioning(
            options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 1);
           
            })
            .AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }).EnableApiVersionBinding();

            return services;
        }
    }
}

