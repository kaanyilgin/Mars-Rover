namespace MarsRover.BL.Map
{
    public class EastCardinalPoint : ICardinalPoint
    {
        public void MoveForward(Point point)
        {
            point.IncrementX();
        }

        public ICardinalPoint GetTurnedLeftCardinalPoint()
        {
            return new NorthCardinalPoint();
        }

        public ICardinalPoint GetTurnedRightCardinalPoint()
        {
            return new SouthCardinalPoint();
        }

        public char GetCardinalPoint()
        {
            return 'E';
        }
    }
}