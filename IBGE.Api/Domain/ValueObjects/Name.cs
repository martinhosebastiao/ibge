﻿using System;
using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;

namespace IBGE.Api.Domain.ValueObjects
{
    public sealed class Name: Notifiable
    {
        protected Name() { }
        public Name(string name)
        {

            if (name.IsNotNullOrEmpty())
            {
                Value = name;
                return;
            }

            AddNotification(name,"O nome indicado é invalido");
        }

        public string? Value { get; set; }
    }
}

