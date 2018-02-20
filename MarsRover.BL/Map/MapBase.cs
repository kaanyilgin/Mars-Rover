using System.Collections.Generic;
using System.Text;
using MarsRover.BL.Rover;

namespace MarsRover.BL.Map
{
    public abstract class MapBase
    {
        internal readonly Point _point;

        protected IList<RoverBase> _rovers;
        public IList<RoverBase> Rovers
        {
            set { _rovers = value; }
        }

        public MapBase(Point point)
        {
            _point = point;
        }

        public abstract void Discover();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var rover in _rovers)
            {
                builder.AppendLine(rover.ToString());
            }

            return builder.ToString();
        }

        public string GetUpperRightCoordinate()
        {
            return $"X: {_point.X} Y: {_point.Y}";
        }

        public bool IsPointInMap(Point point)
        {
            if (point.X < 0)
            {
                return false;
            }

            if (point.Y < 0)
            {
                return false;
            }

            if (point.X > _point.X)
            {
                return false;
            }

            if (point.Y > _point.Y)
            {
                return false;
            }

            return true;
        }
    }
}