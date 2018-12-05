using System;

namespace Epam.Task3.Game
{
    public interface IDoDamage
    {
        IDamageable DoDamage(IDamageable target);
    }
}
