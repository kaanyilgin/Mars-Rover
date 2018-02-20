using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    public abstract class CardinalPointFixtureBase
    {
        protected MarsPoint MarsPoint;
        
        [SetUp]
        public virtual void SetUp()
        {
            MarsPoint = new MarsPoint(0, 0);
        }
    }
}