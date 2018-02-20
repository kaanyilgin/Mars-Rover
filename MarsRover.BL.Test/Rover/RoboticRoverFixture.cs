using System;
using MarsRover.BL.Map;
using MarsRover.BL.Rover;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.BL.Test.Rover
{
    [TestFixture]
    public class RoboticRoverFixture
    {
        private RoboticRover _rover;
        private ICardinalPoint _cardinalPoint;
        private Point _point;
        
        [SetUp]
        public void SetUp()
        {
            _point = Substitute.For<Point>();
            _cardinalPoint = Substitute.For<ICardinalPoint>();
            _rover = new RoboticRover(_point, _cardinalPoint);
        }
        
        [Test]
        public void RoboticRoverMoveForward_WhenFunctionCalled_ShouldCardinalPointMoveForwardCalledOnce()
        {
            //act
            _rover.MoveForward();
            
            //assert
            _cardinalPoint.Received(1).MoveForward(_point);
        }

        [Test]
        public void RoboticRoverTurnLeft_WhenFunctionCalled_ShouldGetTurnedLeftCardinalPointCallOnce()
        {
            //act
            _rover.TurnLeft();
            
            //assert
            _cardinalPoint.Received(1).GetTurnedLeftCardinalPoint();
        }

        [Test]
        public void RoboticRoverTurnRight_WhenFunctionCalled_ShouldGetTurnedRightCardinalPointCallOnce()
        {
            //act
            _rover.TurnRight();
            
            //assert
            _cardinalPoint.Received(1).GetTurnedRightCardinalPoint();
        }
    }
}