using System;
using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class SouthCardinalPointFixture : CardinalPointFixtureBase
    {
        private SouthCardinalPoint _southCardinalPoint;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _southCardinalPoint = new SouthCardinalPoint();
        }
        
        [Test]
        public void SouthCardinalPointMoveForward_WhenYIs0_ShouldYMinus1()
        {
            //act
            _southCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(-1, MarsPoint.Y);
        }
        
        [Test]
        public void SouthCardinalPointMoveForward_WhenXIs0_ShouldX0()
        {
            //act
            _southCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(0, MarsPoint.X);
        }
        
        [Test]
        public void SouthCardinalPointGetTurnedLeftCardinalPoint_WhenFunctionCalled_ShouldTypeEastCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _southCardinalPoint.GetTurnedLeftCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(EastCardinalPoint), newCardinalPoint.GetType());
        }
        
        [Test]
        public void SouthCardinalPointGetTurnedRightCardinalPoint_WhenFunctionCalled_ShouldTypeWestCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _southCardinalPoint.GetTurnedRightCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(WestCardinalPoint), newCardinalPoint.GetType());
        }
    }
}