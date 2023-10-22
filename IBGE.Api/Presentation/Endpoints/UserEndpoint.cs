using System.Security.Claims;
using Asp.Versioning;
using Asp.Versioning.Builder;
using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IBGE.Api.Presentation.Endpoints
{
    public static class UserEndpoint
    {
        public static RouteGroupBuilder MapUser(this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/connecteduser", (ClaimsPrincipal user) =>
            {
                return Results.Ok(new { message = $"Autenticado com {user?.Identity?.Name}" });
            }).WithName("Authentication")
             .RequireAuthorization("Free")
             .MapToApiVersion(new ApiVersion(1, 2));

            route.MapPost($"{routePrefix}/create", async (
                [FromServices] IUserService userService,
                [FromBody] UserModel model) =>
            {

                var result = await userService.CreateAsync(model);
                if (result.Success)
                    return Results.Ok(result);

                return Results.BadRequest(result);
            })
            .WithName("UserCreate")
            .AllowAnonymous();

            route.MapPost($"{routePrefix}/login", async ([FromServices] IUserService userService,
                                                         [FromBody] UserModel model) =>
            {
                var result = await userService.LoginAsync(model.Email, model.Password);

                return result.Success ? Results.Ok(result)
                                      : Results.Unauthorized();

            }).WithName("Login")
              .AllowAnonymous();

            return route;
        }
    }
}
