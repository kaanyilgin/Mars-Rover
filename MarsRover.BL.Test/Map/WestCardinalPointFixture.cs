using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class WestCardinalPointFixture : CardinalPointFixtureBase
    {
        private WestCardinalPoint _westCardinalPoint;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _westCardinalPoint = new WestCardinalPoint();
        }
        
        [Test]
        public void WestCardinalPointMoveForward_WhenYIs0_ShouldYM0()
        {
            //act
            _westCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(0, MarsPoint.Y);
        }
        
        [Test]
        public void WestCardinalPointMoveForward_WhenXIs0_ShouldX0()
        {
            //act
            _westCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(-1, MarsPoint.X);
        }
        
        [Test]
        public void WestCardinalPointGetTurnedLeftCardinalPoint_WhenFunctionCalled_ShouldTypeSouthCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _westCardinalPoint.GetTurnedLeftCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(SouthCardinalPoint), newCardinalPoint.GetType());
        }
        
        [Test]
        public void WestCardinalPointGetTurnedRightCardinalPoint_WhenFunctionCalled_ShouldTypeNorthCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _westCardinalPoint.GetTurnedRightCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(NorthCardinalPoint), newCardinalPoint.GetType());
        }
    }
}