using System;

namespace Epam.Task3.Game
{
    public interface IMovable
    {
        void Move(Field field, IMovable movable);
    }
}
