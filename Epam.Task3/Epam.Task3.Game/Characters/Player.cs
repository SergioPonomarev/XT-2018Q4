using System;

namespace Epam.Task3.Game
{
    public class Player : Character, IBuffable
    {
        public Player(int maxHealth, int strength, int stamina, int agility) : base(maxHealth, strength, stamina, agility)
        {
        }

        public override IDamageable DoDamage(IDamageable target)
        {
            throw new NotImplementedException();
        }

        public IBuffable GetBuff(int buff)
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
