using System;

namespace Epam.Task3.Game
{
    class Fox : Character
    {
        public Fox(int maxHealth, int strength, int stamina, int agility, Position position) : base(maxHealth, strength, stamina, agility, position)
        {
        }

        public override IDamageable DoDamage(IDamageable target)
        {
            throw new NotImplementedException();
        }

        public override IDamageable GetDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public override void Move(Field field, IMovable movable)
        {
            throw new NotImplementedException();
        }
    }
}
