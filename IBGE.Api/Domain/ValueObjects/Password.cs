using System;
using System.Security.Cryptography;
using System.Text;
using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public class Password : Notifiable
    {
        protected Password() { }

        public Password(string password) => Encrypt(password);


        public string? Hash { get; private set; }

        #region - Methods -
        private void Validate(string password)
        {
            // Implementar regras de validação de uma password

            if (password.IsNotNullOrEmpty() == false)
                AddNotification(password, "Password invalida");
        }

        private void Encrypt(string password)
        {
            try
            {
                Validate(password);

                // Encriptar a password caso seja valida

                if (HasValid)
                {
                    var plainText = Encoding.Unicode.GetBytes(password);
                    var plainTextEncripted = Aes.Create().EncryptEcb(plainText, PaddingMode.PKCS7).ToArray();

                    // Atribuir a hash obtida para a propriedade Hash
                    Hash = Convert.ToBase64String(plainTextEncripted).Substring(1, 50);
                }
            }
            catch (Exception)
            {
                AddNotification(password, "Falha no encriptação da password");
            }
        }

        #endregion
    }
}

