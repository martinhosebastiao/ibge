using System;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;

namespace IBGE.Api.Domain.Entities
{
    public class User : Notifiable
    {
        protected User() { }
        public User(string email, string password, bool isUser)
        {
            ChangeRole(isUser);
            ChangeEmail(email);
            ChangePassword(password);
        }

        public short UserId { get; private set; }
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public string Role { get; private set; } = null!;

        #region - Methods -
        public void AddUserId(short userId)
        {
            //Aplicar validações para valores negativos
            UserId = userId;
        }
        public void ChangeRole(bool isUser = true) => Role = isUser ? "User" : "Admin";
        public void ChangeEmail(string email) => Email = new Email(email);
        public void ChangePassword(string password) => Password = new Password(password);
        #endregion

    }
}

