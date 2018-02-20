using System;

namespace MarsRover.BL.Map
{
    public class NorthCardinalPoint : ICardinalPoint
    {
        public void MoveForward(Point point)
        {
            if (point == null) throw new ArgumentNullException(nameof(point));
            point.IncrementY();
        }

        public ICardinalPoint GetTurnedLeftCardinalPoint()
        {
            return new WestCardinalPoint();
        }

        public ICardinalPoint GetTurnedRightCardinalPoint()
        {
            return new EastCardinalPoint();
        }

        public char GetCardinalPoint()
        {
            return 'N';
        }
    }
}