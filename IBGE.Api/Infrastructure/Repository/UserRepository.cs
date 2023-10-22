using IBGE.Api.Domain.Entities;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IBGEContext context, ILoggerFactory logger) : base(context, logger) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
            {
                var result = await context.Users.FirstOrDefaultAsync(x => x.Email.Address == email);

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

