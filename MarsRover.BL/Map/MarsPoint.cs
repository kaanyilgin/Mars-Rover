namespace MarsRover.BL.Map
{
    public class MarsPoint : Point
    {
        public MarsPoint(int x, int y) : base(x, y)
        {
        }

        public override void IncrementY()
        {
            Y++;
        }

        public override void DecrementY()
        {
            Y--;
        }

        public override void IncrementX()
        {
            X++;
        }

        public override void DecrementX()
        {
            X--;
        }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
}