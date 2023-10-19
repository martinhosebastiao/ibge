using System;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;

namespace IBGE.Api.Domain.Entities
{
    public class User
    {
        protected User() {}
        public User(string email, string password)
        {
            ChangeEmail(email);
            ChangePassword(password);
        }

        public short UserId { get; private set; }
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;

        #region - Methods -
        public void ChangeEmail(string email) => Email = new Email(email);
        public void ChangePassword(string password) => Password = new Password(password);
        #endregion

    }
}

