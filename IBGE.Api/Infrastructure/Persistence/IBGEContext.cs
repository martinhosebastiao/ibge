using System;
using IBGE.Api.Domain.Entities;
using IBGE.Api.Infrastructure.Persistence.Map;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Api.Infrastructure.Persistence
{
    public class IBGEContext : DbContext
    {
        public IBGEContext(DbContextOptions<IBGEContext> options) { }

        #region - DbSet Configurations -
        public DbSet<User> Users { get; private set; }
        public DbSet<State> States { get; private set; }
        public DbSet<Town> Towns { get; private set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new TownMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

