using System;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Repository
{
    public class TownRepository : BaseRepository<Town>, ITownRepository
    {
        public TownRepository(IBGEContext context, ILoggerFactory logger) : base(context, logger)
        {
        }

        public async Task<Town?> GetByCodeAsync(int code)
        {
            try
            {
                var result = await context.Towns.AsNoTracking()
                                         .FirstOrDefaultAsync(x => x.Code == code);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return null;
            }
        }

        public async Task<IList<Town>?> GetByNameAsync(string name)
        {
            try
            {
                var result = await context.Towns.Where(x => x.Name.Value!.ToLower()
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

