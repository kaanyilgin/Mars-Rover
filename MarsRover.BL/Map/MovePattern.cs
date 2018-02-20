using System.Collections.Generic;

namespace MarsRover.BL.Map
{
    public class MovePattern
    {
        public IList<DirectionType> Directions { get; }

        public MovePattern(IList<DirectionType> directions)
        {
            Directions = directions;
        }
    }
}