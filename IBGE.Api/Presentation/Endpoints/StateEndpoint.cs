using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace IBGE.Api.Presentation.Endpoints
{
    public static class StateEndpoint
    {
        public static RouteGroupBuilder MapState(this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/getall", async ([FromServices] IStateService stateService) =>
            {
                var result = await stateService.GetAllAsync();

                return result.Success ? Results.Ok(result)
                                      : Results.NotFound(result);

            }).WithName($"GetAll{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapGet($"{routePrefix}/getbycode/{{code:int}}", async (
                [FromServices] IStateService stateService, int code) =>
            {
                var result = await stateService.GetByCodeAsync((byte) code);

                return result.Success ? Results.Ok(result)
                                     : Results.NotFound(result);

            }).WithName($"GetByCode{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapGet($"{routePrefix}/getbyacronym/{{acronym}}", async (
                [FromServices] IStateService stateService, string acronym) =>
            {
                var result = await stateService.GetByAcronymAsync(acronym);

                return result.Success ? Results.Ok(result)
                                     : Results.NotFound(result);

            }).WithName($"Get{routePrefix}ByAcronym")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapGet($"{routePrefix}/getbyname/{{name}}", async (
                [FromServices] IStateService stateService, string name) =>
            {
                var result = await stateService.GetByNameAsync(name);

                return result.Success ? Results.Ok(result)
                                      : Results.NotFound(result);

            }).WithName($"Get{routePrefix}ByName")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);



            route.MapPost($"{routePrefix}/", async (
                [FromServices] IStateService stateService, [FromBody] StateModel model) =>
            {

                var result = await stateService.CreateAsync(model);

                return result.Success ? Results.Ok(result)
                                      : Results.BadRequest(result);
            }).WithName($"Create{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);



            route.MapPut($"{routePrefix}/{{id}}", async (
                [FromServices] IStateService stateService, [FromBody] StateModel model,
                int id) =>
            {
                model.AddStateId((byte) id);

                var result = await stateService.UpdateAsync(model);

                return result.Success ? Results.Ok(result)
                                      : Results.BadRequest(result);
            }).WithName($"Update{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);



            route.MapDelete($"{routePrefix}/{{id:int}}", async (
                [FromServices] IStateService userService, int id) =>
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

