using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public class Password : Notifiable
    {
        protected Password() { }

        public Password(string password)
        {
            // Implementar regras de validação de uma password

            if (password.IsNotNullOrEmpty())
            {
                Hash = password;
                return;
            }
            AddNotification(password, "Password invalida");
        }

        public string? Hash { get; private set; }
    }
}

