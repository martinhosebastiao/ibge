using System;
using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public sealed class Name: Notifiable
    {
        public Name(string name)
        {

            if (name.IsNotNullOrEmpty())
            {
                Value = name;
                return;
            }

            AddNotification(Value,"Nome invalido");
        }

        public string Value { get; set; }
    }
}

