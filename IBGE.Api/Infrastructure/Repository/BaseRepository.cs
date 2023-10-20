using System;
using System.Linq.Expressions;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Repository
{
	public abstract class BaseRepository<Entity> : IDisposable, IBaseRepository<Entity> where Entity : class
    {
        internal readonly IBGEContext context;
        internal readonly DbSet<Entity> DbSet;
        internal readonly ILogger logger;

        public BaseRepository(IBGEContext context, ILogger logger)
		{
            this.context = context;
            this.logger = logger;
            DbSet = this.context.Set<Entity>();
		}

        public async Task<IList<Entity>> GetAllAsync()
        {
            try
            {
                var data = await DbSet.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex,ex?.Message);

                return new List<Entity>();
            }
        }

        public async Task<Entity?> GetIdAsync<Type>(Type id)
        {
            try
            {
                var data = await DbSet.FindAsync();

                return data;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return null;
            }
        }

        public async Task<dynamic> FindAsync(Expression<Func<Entity, bool>> condition)
        {
            try
            {
                var data = await DbSet.Where(condition).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return string.Empty;
            }
        }

        public async Task<Entity?> CreateAsync(Entity entity)
        {
            try
            {
                var data = await DbSet.AddAsync(entity);

                return data.Entity;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return null;
            }
        }

        public Entity? Update(Entity entity)
        {
            try
            {
                var data = DbSet.Update(entity);

                return data.Entity;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return null;
            }
        }

        public bool Delete(Entity entity)
        {
            try
            {
                var data =  DbSet.Remove(entity);

                return data.Entity == entity;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}

