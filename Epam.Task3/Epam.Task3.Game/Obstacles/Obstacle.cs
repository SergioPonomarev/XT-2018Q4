using System;

namespace Epam.Task3.Game
{
    public abstract class Obstacle : IPositionable
    {
        public Obstacle(Position position)
        {
            this.CurrentPosition = position;
        }

        public Position CurrentPosition { get; private set; }
    }
}
