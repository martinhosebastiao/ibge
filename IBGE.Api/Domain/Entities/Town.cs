using System;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;
using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Domain.Entities
{
    public class Town
    {
        public Town(byte stateCode, string name)
        {
            ChangeState(stateCode);
            ChangeName(name);
        }

        public int TownId { get; private set; }
        public byte StateId { get; private set; }
        public Name Name { get; private set; } = null!;
        public virtual State? State { get; private set; }

        #region - Methods -
        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        /// <summary>
        /// Modificar o codigo da propriedade Estado
        /// </summary>
        /// <param name="stateCode">Codigo do Estado no valor interiro</param>
        public void ChangeState(byte stateCode)
        {
            StateId = stateCode;
        }

        /// <summary>
        /// Modificar a entidade Estado
        /// </summary>
        /// <param name="state">Entidade</param>
        public void AddState(State state)
        {
            State = state;
        }
        #endregion

    }
}

