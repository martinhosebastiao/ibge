using IBGE.Api.Application.Interfaces;
using IBGE.Api.Application.Models;
using IBGE.Api.Domain.Interfaces.Repositores;

namespace IBGE.Api.Application.Services
{
    public class UserService : IUserService
    {
        protected readonly ILogger logger;
        protected readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, ILoggerFactory logger)
        {
            this.logger = logger.CreateLogger("logs");
            this.userRepository = userRepository;
        }

        public async Task<DefaultResult> CreateAsync(UserModel model)
        {
            try
            {
                var user = model.ConvertToUser();

                if (user.HasValid)
                {
                    var checkEmail = await userRepository.GetByEmailAsync(user.Email.Address!);

                    if (checkEmail == null)
                    {
                        var result = await userRepository.CreateAsync(user);

                        await userRepository.CompleteAsync();

                        return new DefaultResult(true, $"User code {result?.UserId} created successfully, privilege {result?.Role}");
                    }
                    return new DefaultResult(Message: "The email address is already in use");
                }
                return new DefaultResult(Notifications: user.Notifications.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                return new DefaultResult(Message: "An error occurred, tryagain later.!");
            }
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            try
            {
                var user = await userRepository.GetByEmailAsync(email);

                if (user != null)
                    if (user.Password.Hash == password)
                    {
                        var token = TokenService.GenerateToken(user);
                        return new LoginResult(true, token);
                    }

                return new LoginResult(false, "Invalid username or password");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return new LoginResult(false, "An error occurred, tryagain later.!");
            }
        }

    }
}

