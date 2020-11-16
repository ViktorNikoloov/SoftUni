using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        public void AddPrivate(ISoldier @private);
        
    }
}
