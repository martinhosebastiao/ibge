using System;
namespace IBGE.Domains.Core.Entities
{
	public class State
	{
		private readonly List<Town> towns;

		protected State() { }
        public State(string name, string acronym)
		{
			ChangeName(name);
			ChangeAcronym(acronym);
		}

		public int StateId { get; private set; }
		public string Acronym { get; private set; }
		public string Name { get; private set; }
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

