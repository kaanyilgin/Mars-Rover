namespace MarsRover.BL.Map
{
    public interface ICardinalPoint
    {
        void MoveForward(Point point);

        ICardinalPoint GetTurnedLeftCardinalPoint();

        ICardinalPoint GetTurnedRightCardinalPoint();

        char GetCardinalPoint();
    }
}