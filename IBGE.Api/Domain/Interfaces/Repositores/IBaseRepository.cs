using System.Linq.Expressions;

namespace IBGE.Api.Domain.Interfaces.Repositores
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<IList<Entity>> GetAllAsync();
        Task<Entity?> GetIdAsync<Type>(Type id);
        Task<dynamic> FindAsync(Expression<Func<Entity, bool>> condition);
        Task<Entity?> CreateAsync(Entity entity);
        Entity? Update(Entity entity);
        bool Delete(Entity entity);
    }
}

