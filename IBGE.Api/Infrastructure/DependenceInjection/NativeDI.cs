using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Services;
using IBGE.Api.Domain.Interfaces.Repositores;
using IBGE.Api.Infrastructure.Persistence;
using IBGE.Api.Infrastructure.Repository;

namespace IBGE.Api.Infrastructure.DependenceInjection
{
    public static class NativeDI
    {
        public static IServiceCollection AddProjectDependences(this IServiceCollection services)
        {
            #region - Applications -
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ITownService, TownService>();
            #endregion

            #region - Repository -
            services.AddDbContext<IBGEContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ITownRepository, TownRepository>();
            #endregion

            return services;
        }
    }
}

