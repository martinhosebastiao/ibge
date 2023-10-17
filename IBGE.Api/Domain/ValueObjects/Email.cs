using System;
namespace IBGE.Api.Domains.ValueObjects
{
    public sealed class Email
    {
        protected Email() { }
        public Email(string email) => Validate(email);

        public string Address { get; private set; }

        private void Validate(string email)
        {
            // Validar se o email é valido
        }
    }
}

