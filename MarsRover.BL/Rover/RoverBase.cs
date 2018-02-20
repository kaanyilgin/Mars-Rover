using System;
using MarsRover.BL.Map;

namespace MarsRover.BL.Rover
{
    public abstract class RoverBase
    {
        private readonly Point _point;
        internal Point Point
        {
            get { return _point; }
        }

        internal ICardinalPoint _cardinalPoint;
        public MovePattern MovePattern { get; set; }

        public RoverBase(Point point, ICardinalPoint cardinalPoint)
        {
            _point = point ?? throw new ArgumentNullException(nameof(point));
            _cardinalPoint = cardinalPoint ?? throw new ArgumentNullException(nameof(cardinalPoint));
        }

        internal abstract void MoveForward();

        internal abstract void TurnLeft();

        internal abstract void TurnRight();

        internal abstract void Move();

        public override string ToString()
        {
            return $"{_point.X} {_point.Y} {_cardinalPoint.GetCardinalPoint()}";
        }
    }
}