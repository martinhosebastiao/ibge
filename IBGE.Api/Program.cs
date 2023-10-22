using Asp.Versioning;
using IBGE.Api.Domain.Shared;
using IBGE.Api.Infrastructure.DependenceInjection;
using IBGE.Api.Presentation.Configurations.Extensions;
using IBGE.Api.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var version1 = new ApiVersion(1,1);
var version2 = new ApiVersion(1,2);


//Obter a string de conexão apartir do ficheiro de configuração
AppSetting.ConnectionString = builder.Configuration.GetConnectionString("IBGEConnection") ?? string.Empty;

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddLogging();
builder.Services.AddSwaggerCustom();
builder.Services.AddSecurityCustom();
builder.Services.AddProjectDependences();
builder.Services.AddApiVersioningCustom();
builder.Services.AddEndpointsApiExplorer();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsProduction())
{
    //Garante o reencaminhamento https dos request, deve sempre estar antes de qualquer middleware
    app.Use((context, next) =>
    {
        context.Request.Scheme = "https";
        return next();
    });
}

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

var route = app.NewVersionedApi()
               .MapGroup(AppSetting.PrefixRoute)
               .HasApiVersion(version1)
               .HasApiVersion(version2)
               .RequireAuthorization();

route.MapUser("/user")
     .MapState("/state")
     .MapTown("/town");

app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerCustom();
app.UseHttpsRedirection();

app.Run();


