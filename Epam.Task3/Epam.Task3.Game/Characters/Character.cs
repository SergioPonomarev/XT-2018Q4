using System;

namespace Epam.Task3.Game
{
    public abstract class Character : IDamageable, IDoDamage, IMovable, IPositionable
    {
        private const int MinHealth = 0;

        public Character(int maxHealth, int strength, int stamina, int agility, Position position)
        {
            this.MaxHealth = maxHealth;
            this.Strength = strength;
            this.Stamina = stamina;
            this.Agility = agility;
            this.CurrentPosition = position;
        }

        public int MaxHealth { get; private set; }

        public int CurrentHealth { get; private set; }

        public int Strength { get; private set; }

        public int Stamina { get; private set; }

        public int Agility { get; private set; }

        public Position CurrentPosition { get; private set; }

        public abstract IDamageable DoDamage(IDamageable target);

        public abstract IDamageable GetDamage(int damage);

        public abstract void Move(Field field, IMovable movable);
    }
}
