using Asp.Versioning;
using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IBGE.Api.Presentation.Endpoints
{
    public static class TownEndpoint
	{
        public static RouteGroupBuilder MapTown(this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/getall", async ([FromServices] ITownService townService) =>
            {
                var result = await townService.GetAllAsync();

                return result.Success ? Results.Ok(result)
                                      : Results.NotFound(result);

            }).WithName($"GetAll{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapGet($"{routePrefix}/getbycode/{{code:int}}", async (
                [FromServices] ITownService townService, int code) =>
            {
                var result = await townService.GetByCodeAsync(code);

                return result.Success ? Results.Ok(result)
                                     : Results.NotFound(result);

            }).WithName($"Get{routePrefix}ByCode")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapGet($"{routePrefix}/getbyname/{{name}}", async (
                [FromServices] ITownService townService, string name) =>
            {
                var result = await townService.GetByNameAsync(name);

                return result.Success ? Results.Ok(result)
                                      : Results.NotFound(result);

            }).WithName($"Get{routePrefix}ByName")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapPost($"{routePrefix}/", async (
                [FromServices] ITownService townService, [FromBody] TownModel model) =>
            {

                var result = await townService.CreateAsync(model);

                return result.Success ? Results.Ok(result)
                                      : Results.BadRequest(result);
            }).WithName($"Create{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);



            route.MapPut($"{routePrefix}/{{id:int}}", async (
                [FromServices] ITownService townService, [FromBody] TownModel model,
                int id) =>
            {
                model.AddTownId((short)id);

                var result = await townService.UpdateAsync(model);

                return result.Success ? Results.Ok(result)
                                      : Results.BadRequest(result);
            }).WithName($"Update{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);



            route.MapDelete($"{routePrefix}/{{id:int}}", async (
                [FromServices] ITownService userService, int id) =>
            {
                var result = await userService.DeleteAsync((byte)id);

                return result.Success ? Results.Ok(result)
                                     : Results.BadRequest(result);

            }).WithName($"Delete{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);

            return route;
        }
    }
}

