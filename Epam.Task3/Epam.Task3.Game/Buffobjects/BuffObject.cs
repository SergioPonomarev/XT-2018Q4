using System;

namespace Epam.Task3.Game
{
    public abstract class BuffObject : IBuffable, IPositionable
    {
        public BuffObject(Position position)
        {
            this.CurrentPosition = position;
        }

        public Position CurrentPosition { get; private set; }

        public abstract IBuffable GetBuff(int buff);
    }
}
