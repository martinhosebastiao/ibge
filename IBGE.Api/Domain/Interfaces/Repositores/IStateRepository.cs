using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Domain.Interfaces.Repositores
{
    public interface IStateRepository: IBaseRepository<State>
    {
        Task<State?> GetByCodeAsync(byte code);
        Task<State?> GetByAcronymAsync(string acronym);
        Task<IList<State>?> GetByNameAsync(string name);
    }
}