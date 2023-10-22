using System;
using IBGE.Api.Domain.Extensions;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;

namespace IBGE.Api.Domain.Entities
{
    public class State : Notifiable
    {
        private readonly List<Town> towns = new();

        protected State() { }
        public State(byte code, string acronym, string name)
        {
            ChangeCode(code);
            ChangeAcronym(acronym);
            ChangeName(name);
        }

        public byte StateId { get; private set; }
        public byte Code { get; private set; }
        public string Acronym { get; private set; } = null!;
        public Name Name { get; private set; } = null!;
        public virtual IReadOnlyCollection<Town> Towns { get => towns; }

        #region - Methods -
        public void AddStateId(byte stateId)
        {
            // Aplicar validação de numero negativo
            StateId = stateId;
        }

        public void ChangeCode(byte code)
        {
            // Aplicar validação de numero negativo
            Code = code;
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public void ChangeAcronym(string acronym)
        {
            if (acronym.IsNotNullOrEmpty())
            {
                Acronym = acronym;
                return;
            }

            AddNotification(acronym, "Sigla invalida");
        }
        #endregion

    }
}

