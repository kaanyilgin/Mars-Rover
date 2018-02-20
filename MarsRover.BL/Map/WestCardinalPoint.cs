namespace MarsRover.BL.Map
{
    public class WestCardinalPoint : ICardinalPoint
    {
        public void MoveForward(Point point)
        {
            point.DecrementX();
        }

        public ICardinalPoint GetTurnedLeftCardinalPoint()
        {
            return new SouthCardinalPoint();
        }

        public ICardinalPoint GetTurnedRightCardinalPoint()
        {
            return new NorthCardinalPoint();
        }

        public char GetCardinalPoint()
        {
            return 'W';
        }
    }
}