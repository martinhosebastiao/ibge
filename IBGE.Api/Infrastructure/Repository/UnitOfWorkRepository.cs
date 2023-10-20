using System;
using IBGE.Api.Domain.Interfaces.Repositores;

namespace IBGE.Api.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IUserRepository User => throw new NotImplementedException();

        public IStateRepository State => throw new NotImplementedException();

        public ITownRepository Town => throw new NotImplementedException();

        public Task<bool> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}

