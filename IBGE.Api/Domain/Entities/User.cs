using System;
using IBGE.Domains.Core.ValueObjects;

namespace IBGE.Api.Domains.Entities
{
    public class User
    {
        protected User() {}
        public User(string email, string password)
        {
            ChangeEmail(email);
            ChangePassword(password);
        }

        public int UserId { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        #region - Methods -
        public void ChangeEmail(string email) => Email = new Email(email);
        public void ChangePassword(string password) => Password = new Password(password);
        #endregion

    }
}

