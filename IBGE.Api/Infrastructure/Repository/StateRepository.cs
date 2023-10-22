using System;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Repository
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(IBGEContext context, ILoggerFactory logger) : base(context, logger) { }

        public async Task<State?> GetByAcronymAsync(string acronym)
        {
            try
            {
                var result = await context.States.AsNoTracking()
                                          .FirstOrDefaultAsync(x => x.Acronym.ToLower()
                                                                .Equals(acronym.ToLower()));

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return null;
            }
        }

        public async Task<State?> GetByCodeAsync(byte code)
        {
            try
            {
                var result = await context.States.AsNoTracking()
                                          .FirstOrDefaultAsync(x => x.Code == code);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return null;
            }
        }

        public async Task<IList<State>?> GetByNameAsync(string name)
        {
            try
            {
                var result = await context.States.Where(x => x.Name.Value!.ToLower()
                                                              .Contains(name.ToLower()) == true)
                                                 .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return null;
            }
        }
    }
}

