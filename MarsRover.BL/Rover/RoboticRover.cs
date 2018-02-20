using System;
using MarsRover.BL.Map;

namespace MarsRover.BL.Rover
{
    public class RoboticRover : RoverBase
    {
        public RoboticRover(Point point, ICardinalPoint cardinalPoint) : base(point, cardinalPoint)
        {
        }

        internal override void MoveForward()
        {
            _cardinalPoint.MoveForward(Point);
        }

        internal override void TurnLeft()
        {
            _cardinalPoint = _cardinalPoint.GetTurnedLeftCardinalPoint();
        }

        internal override void TurnRight()
        {
            _cardinalPoint = _cardinalPoint.GetTurnedRightCardinalPoint();
        }

        internal override void Move()
        {
            foreach (var patternDirection in MovePattern.Directions)
            {
                switch (patternDirection)
                {
                    case DirectionType.Right:
                        TurnRight();
                        break;
                    case DirectionType.Left:
                        TurnLeft();
                        break;
                    case DirectionType.Move:
                        MoveForward();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}