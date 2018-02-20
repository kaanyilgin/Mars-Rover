using System;
using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class NorthCardinalPointFixture : CardinalPointFixtureBase
    {
        private NorthCardinalPoint _northCardinalPoint;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _northCardinalPoint = new NorthCardinalPoint();
        }

        [Test]
        public void NorthCardinalPointMoveForward_WhenPositionIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            MarsPoint marsPoint = null;
            
            //act
            TestDelegate testDelegate = () => _northCardinalPoint.MoveForward(marsPoint);
            
            //assert
            Assert.Throws<ArgumentNullException>(testDelegate);
        }

        [Test]
        public void NorthCardinalPointMoveForward_WhenYIs0_ShouldY1()
        {
            //act
            _northCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(1, MarsPoint.Y);
        }
        
        [Test]
        public void NorthCardinalPointMoveForward_WhenXIs0_ShouldX0()
        {
            //act
            _northCardinalPoint.MoveForward(MarsPoint);
            
            //assert
            Assert.AreEqual(0, MarsPoint.X);
        }
        
        [Test]
        public void NorthCardinalPointGetTurnedLeftCardinalPoint_WhenFunctionCalled_ShouldTypeWestCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _northCardinalPoint.GetTurnedLeftCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(WestCardinalPoint), newCardinalPoint.GetType());
        }
        
        [Test]
        public void NorthCardinalPointGetTurnedRightCardinalPoint_WhenFunctionCalled_ShouldTypeEastCardinalPoint()
        {
            //act
            ICardinalPoint newCardinalPoint =  _northCardinalPoint.GetTurnedRightCardinalPoint();
            
            //assert
            Assert.AreEqual(typeof(EastCardinalPoint), newCardinalPoint.GetType());
        }
    }
}