namespace MarsRover.BL.Map
{
    public class SouthCardinalPoint : ICardinalPoint
    {
        public void MoveForward(Point point)
        {
            point.DecrementY();
        }

        public ICardinalPoint GetTurnedLeftCardinalPoint()
        {
            return new EastCardinalPoint();
        }

        public ICardinalPoint GetTurnedRightCardinalPoint()
        {
            return new WestCardinalPoint();
        }

        public char GetCardinalPoint()
        {
            return 'S';
        }
    }
}