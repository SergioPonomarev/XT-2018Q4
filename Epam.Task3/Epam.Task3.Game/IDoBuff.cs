using System;

namespace Epam.Task3.Game
{
    public interface IDoBuff
    {
        IBuffable DoBuff(IBuffable target);
    }
}
