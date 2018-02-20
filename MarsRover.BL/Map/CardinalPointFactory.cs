using System;

namespace MarsRover.BL.Map
{
    public class CardinalPointFactory : ICardinalPointFactory
    {
        public ICardinalPoint GetCardinalPoint(char cardinalPoint)
        {
            switch (cardinalPoint)
            {
                case 'N':
                    return new NorthCardinalPoint();
                case 'E':
                    return new EastCardinalPoint();
                case 'S':
                    return new SouthCardinalPoint();
                case 'W':
                    return new WestCardinalPoint();
                default:
                    throw new InvalidOperationException("Unknown cardinal point");
            }
        }
    }
}