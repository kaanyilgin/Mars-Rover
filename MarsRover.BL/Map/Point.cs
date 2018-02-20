namespace MarsRover.BL.Map
{
    public abstract class Point
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        // for test purpose
        public Point()
        {
            
        }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void IncrementY();
        public abstract void DecrementY();
        public abstract void IncrementX();
        public abstract void DecrementX();
    }
}