using System;
using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    public class EastCardinalPointFixture : CardinalPointFixtureBase
    {
        private EastCardinalPoint _eastCardinalPoint;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _eastCardinalPoint = new EastCardinalPoint();
        }

        [Test]
        public void EastCardinalPointMoveForward_WhenYIs0_ShouldY0()
        {
            //act
            _eastCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(0, MarsPoint.Y);
        }
        
        [Test]
        public void EastCardinalPointMoveForward_WhenXIs0_ShouldX1()
        {
            //act
            _eastCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(1, MarsPoint.X);
        }
        
        [Test]
        public void EastCardinalPointGetTurnedLeftCardinalPoint_WhenFunctionCalled_ShouldTypeNorthCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _eastCardinalPoint.GetTurnedLeftCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(NorthCardinalPoint), newCardinalPoint.GetType());
        }
        
        [Test]
        public void EastCardinalPointGetTurnedRightCardinalPoint_WhenFunctionCalled_ShouldTypeSouthCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _eastCardinalPoint.GetTurnedRightCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(SouthCardinalPoint), newCardinalPoint.GetType());
        }
    }
}