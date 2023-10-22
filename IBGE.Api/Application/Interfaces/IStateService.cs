using IBGE.Api.Application.Models;

namespace IBGE.Api.Application.Interfaces
{
    public interface IStateService
    {
		Task<DefaultResult> GetAllAsync();
		Task<DefaultResult> GetByCodeAsync(byte code);
        Task<DefaultResult> GetByAcronymAsync(string acronym);
        Task<DefaultResult> GetByNameAsync(string name);
		Task<DefaultResult> CreateAsync(StateModel model);
        Task<DefaultResult> UpdateAsync(StateModel model);
        Task<DefaultResult> DeleteAsync(byte stateId);
    }
}

