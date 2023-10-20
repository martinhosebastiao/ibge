using System;
using System.Xml.Linq;
using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string email)
        {
            if (email.IsNotNullOrEmpty())
            {
                Address = email;
                return;
            }

            AddNotification(email, "O email indicado é invalido");
        }

        public string? Address { get; private set; }

    }
}

