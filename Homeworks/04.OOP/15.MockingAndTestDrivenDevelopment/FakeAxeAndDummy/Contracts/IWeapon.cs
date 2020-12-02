using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        public void Attack(ITarget target);
    }
}
