using System;
using System.Linq.Expressions;

namespace IBGE.Api.Domain.Interfaces.Repositores
{
	public interface IBaseRepository<Entity> where Entity : class
    {
        Task<IList<Entity>?> GetAllAsync();
        Task<Entity?> GetByIdAsync<Type>(Type id);
        Task<Entity?> CreateAsync(Entity entity);
        Entity? Update(Entity entity);
        bool Delete(Entity entity);

        /// <summary>
        /// Guardar todo o contexto usado pelo entityframework
        /// </summary>
        /// <returns>Retorna um bool</returns>
        Task<int> CompleteAsync();

        /// <summary>
        /// Desfazer todo o contexto usado pelo entityframework
        /// </summary>
        /// <returns></returns>
        Task<bool> RollbackAsync();
    }
}

