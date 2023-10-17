using System;
namespace IBGE.Api.Domains.Entities
{
    public class Town
    {
        public Town(int stateCode, string name)
        {
            ChangeState(stateCode);
            ChangeName(name);
        }

        public int TownId { get; private set; }
        public int StateId { get; private set; }
        public string Name { get; private set; }
        public virtual State State { get; private set; }

        #region - Methods -
        public void ChangeName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Modificar o codigo da propriedade Estado
        /// </summary>
        /// <param name="stateCode">Codigo do Estado no valor interiro</param>
        public void ChangeState(int stateCode)
        {
            StateId = stateCode;
        }

        /// <summary>
        /// Modificar a entidade Estado
        /// </summary>
        /// <param name="state">Entidade</param>
        public void ChangeState(State state)
        {
            State = state;
        }
        #endregion

    }
}

