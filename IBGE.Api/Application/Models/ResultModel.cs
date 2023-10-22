using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Application.Models
{
    public record LoginResult(bool Success, string Token);
    public record TownResult(short TownId, byte StateId, int Code, string? Name);
    public record StateResult(byte StateId, byte Code, string Acronym, string? Name);
    public record DefaultResult(bool Success = false, string? Message = null,
                                object? Data = null, List<Notification>? Notifications = null);

}

