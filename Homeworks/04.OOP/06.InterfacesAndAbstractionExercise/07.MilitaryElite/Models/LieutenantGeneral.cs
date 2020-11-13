using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        ICollection<IPrivate> privates;

        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)privates;

        public void AddPrivate(IPrivate @private)
        => privates.Add(@private);
    }
}
