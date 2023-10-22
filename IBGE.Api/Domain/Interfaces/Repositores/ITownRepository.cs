using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Domain.Interfaces.Repositores
{
    public interface ITownRepository : IBaseRepository<Town>
    {
        Task<IList<Town>?> GetByNameAsync(string name);
        Task<Town?> GetByCodeAsync(int code);
    }
}

