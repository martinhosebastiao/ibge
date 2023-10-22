using IBGE.Api.Application.Models;

namespace IBGE.Api.Application.Interfaces
{
    public interface IUserService
	{
        Task<LoginResult> LoginAsync(string email, string password);
        Task<DefaultResult> CreateAsync(UserModel model);
    }
}

