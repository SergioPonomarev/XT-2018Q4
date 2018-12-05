using System;

namespace Epam.Task3.Game
{
    public class Cherry : BuffObject
    {
        public Cherry(Position position) : base(position)
        {
        }

        public override IBuffable GetBuff(int buff)
        {
            throw new NotImplementedException();
        }
    }
}
