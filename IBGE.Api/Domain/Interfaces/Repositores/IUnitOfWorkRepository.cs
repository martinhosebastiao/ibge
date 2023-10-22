using System;
namespace IBGE.Api.Domain.Interfaces.Repositores
{
    public interface IUnitOfWorkRepository 
    {
        IUserRepository User { get; }
        IStateRepository State { get; }
        ITownRepository Town { get; }

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

