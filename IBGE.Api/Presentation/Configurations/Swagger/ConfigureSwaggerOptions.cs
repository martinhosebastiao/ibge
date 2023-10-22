using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IBGE.Api.Presentation.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provide) => provider = provide;

        public void Configure(SwaggerGenOptions options)
        {
            // Configuração da documentação da API e possivel customização dos documentos depreciados
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));

        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Version = description.ApiVersion.ToString(),
                Title = "IBGE -  Instituto Brasileiro de Geografia e Estatistica",
                Description = "Desafio de .Net Core 7+, organizado pelo Balta.io",
                TermsOfService = new Uri("https://github.com/martinhosebastiao/ibge/blob/main/README.md"),
                Contact = new OpenApiContact
                {
                    Name = "Grupo 13 - Martinho Sebastião e Bruno Silva",
                    Url = new Uri("https://github.com/martinhosebastiao/ibge/tree/main")
                },
                License = new OpenApiLicense
                {
                    Name = "",
                    Url = new Uri("https://github.com/martinhosebastiao/ibge/blob/main/LICENSE")
                }
            };

            if (description.IsDeprecated)
                info.Description += "Esta vevrsão da API esta depreciada.";

            return info;
        }
    }
}

