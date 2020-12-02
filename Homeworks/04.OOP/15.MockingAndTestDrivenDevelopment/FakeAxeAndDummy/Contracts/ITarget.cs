using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Contracts
{
    public interface ITarget
    {
        public int Health { get; }

        public void TakeAttack(int attackPoints);

        public int GiveExperience();

        public bool IsDead();
    }
}
