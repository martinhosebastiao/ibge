using System;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string email)
        {

        }

        public string? Address { get; private set; }

    }
}

