using System;
namespace IBGE.Api.Domains.ValueObjects
{
    public sealed class Password
    {
        protected Password() { }

        public Password(string password) => Encrypt(password);


        public string Hash { get; private set; }

        #region - Methods -
        private void Validate(string password)
        {
            // Implementar regras de validação de uma password
        }
        private void Encrypt(string password)
        {
            Validate(password);

            // Encriptar a password caso seja valida
            // Atribuir a hash obtida para a propriedade Has
        }
        public bool Compare(string password)
        {
            // Encriptar a password recebido no parametro
            // Comparar se password é igual Hash existente na propriedade

            return false;
        }
        #endregion
    }
}

