using System;
using System.Collections.Generic;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Repository
{
    public class BaseRepository<Entity> : IDisposable, IBaseRepository<Entity> where Entity : class
    {
        internal readonly ILogger logger;
        internal readonly IBGEContext context;
        private readonly DbSet<Entity> dbSet;
        public BaseRepository(IBGEContext context, ILoggerFactory logger)
        {
            this.logger = logger.CreateLogger("");
            this.context = context;
            dbSet = this.context.Set<Entity>();
        }


        public async Task<IList<Entity>?> GetAllAsync()
        {
            try
            {
                var data = await dbSet.AsNoTracking().ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return null;
            }
        }

        public async Task<Entity?> GetByIdAsync<Type>(Type id)
        {
            try
            {
                var data = await dbSet.FindAsync(id);

                return data;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return null;
            }
        }

        public async Task<Entity?> CreateAsync(Entity entity)
        {
            try
            {
                var data = await dbSet.AddAsync(entity);

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
                var data = dbSet.Update(entity);

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
                var data = dbSet.Remove(entity);

                return data.Entity == entity;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex?.Message);

                return false;
            }
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                var result = await context.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<bool> RollbackAsync()
        {
            try
            {
                await context.DisposeAsync();
                return true;
            }
            catch (Exception)
            {
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

