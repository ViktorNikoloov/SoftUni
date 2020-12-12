using System;
using System.Linq;

using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int BeginnerHealthBonusPoints = 40;
        private const int BeginnerDamagehBonusPoints = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += BeginnerHealthBonusPoints;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += BeginnerDamagehBonusPoints;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += BeginnerHealthBonusPoints;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += BeginnerDamagehBonusPoints;
                }
            }

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();

            while (true)
            {
                int attackerDmgPoints = attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();

                enemyPlayer.TakeDamage(attackerDmgPoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyDmgPoints = enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();

                attackPlayer.TakeDamage(enemyDmgPoints
                    );
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
