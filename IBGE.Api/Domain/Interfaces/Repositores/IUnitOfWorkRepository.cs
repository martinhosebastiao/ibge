using System;
namespace IBGE.Api.Domain.Interfaces.Repositores
{
	public interface IUnitOfWorkRepository
	{
        IUserRepository User { get; }
        IStateRepository State { get; }
        ITownRepository Town { get; }

        /// <summary>
        /// Guarda todo o contexto usado pelo entityframework
        /// </summary>
        /// <returns></returns>
        Task<bool> CompleteAsync();
    }
}

