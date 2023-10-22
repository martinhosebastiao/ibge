using IBGE.Api.Application.Models;

namespace IBGE.Api.Application.Interfaces
{
    public interface ITownService
    {
        Task<DefaultResult> GetAllAsync();
        Task<DefaultResult> GetByNameAsync(string name);
        Task<DefaultResult> GetByCodeAsync(int code);
        Task<DefaultResult> CreateAsync(TownModel town);
        Task<DefaultResult> UpdateAsync(TownModel town);
        Task<DefaultResult> DeleteAsync(byte townId);
    }
}

