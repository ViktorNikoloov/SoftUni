﻿using System;

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;


namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health ;

        private readonly ICardRepository cardRepository;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            Username = username;
            Health = health;
            this.cardRepository = cardRepository;
        }

        public ICardRepository CardRepository => cardRepository;

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                health = value;
            }
        }

        public bool IsDead => Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (Health < damagePoints)
            {
                Health = 0;
            }
            else
            {
                Health -= damagePoints;
            }
        }
    }
}
