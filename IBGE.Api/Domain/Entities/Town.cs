using IBGE.Api.Application.Models;
using IBGE.Api.Domain.Notifications;
using IBGE.Api.Domain.ValueObjects;

namespace IBGE.Api.Domain.Entities
{
    public class Town : Notifiable
    {
        protected Town() { }
        public Town(byte stateCode, int code, string name)
        {
            ChangeState(stateCode);
            ChangeCode(code);
            ChangeName(name);
        }

        public short TownId { get; private set; }
        public byte StateId { get; private set; }
        public int Code { get; private set; }
        public Name Name { get; private set; } = null!;
        public virtual State? State { get; private set; }

        #region - Methods -

        public void AddTownId(short townId) => TownId = GreaterOrEqualThan(townId, TownId);

        public void ChangeCode(int code) => Code = GreaterOrEqualThan(code, Code);

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        /// <summary>
        /// Modificar o codigo da propriedade Estado
        /// </summary>
        /// <param name="stateCode">Codigo do Estado no valor interiro</param>
        public void ChangeState(byte stateCode) => StateId = GreaterOrEqualThan(stateCode, StateId);

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

