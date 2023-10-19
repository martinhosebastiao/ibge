using System;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;

namespace IBGE.Api.Domain.Entities
{
    public class State: Notifiable
    {
        private readonly List<Town> towns = new();

        protected State() { }
        public State(string name, string acronym)
        {
            ChangeName(name);
            ChangeAcronym(acronym);
        }

        public byte StateId { get; private set; }
        public string Acronym { get; private set; } = null!;
        public Name Name { get; private set; } = null!;
        public virtual IReadOnlyCollection<Town> Towns { get => towns; }

        #region - Methods -
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void ChangeAcronym(string acronym)
        {
            Acronym = acronym;
        }
        #endregion

    }
}

