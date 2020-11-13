using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
        
    }
}
