using System;

namespace Epam.Task3.Game
{
    public class Apple : BuffObject
    {
        public Apple(Position position) : base(position)
        {
        }

        public override IBuffable GetBuff(int buff)
        {
            throw new NotImplementedException();
        }
    }
}
