using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using MarsRover.BL.Map;
using MarsRover.BL.Rover;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class MarsMapFixture
    {
        private MarsMap _map;

        [SetUp]
        public void SetUp()
        {
            Point point = new MarsPoint(5, 5);
            _map = new MarsMap(point);
        }

        [Test]
        public void Discover_WhenThereIsOneRiverOn4x4_ShouldMoveCalledOnce()
        {
            //arrange 
            Point point = new MarsPoint(4, 4);
            ICardinalPoint cardinalPoint = new EastCardinalPoint();
            RoverStub rover = new RoverStub(point, cardinalPoint);
            _map.Rovers = new List<RoverBase>()
            {
                rover
            };

            //act
            _map.Discover();

            //assert
            Assert.AreEqual(1, rover.MoveCalledCount);
        }

        [Test]
        public void Discover_WhenRoverIsOn1_2NPatternIsLMLMLMLMM_ShouldLastPositionIs1_3_N()
        {
            //arrange
            var directions = new List<DirectionType>()
            {
                DirectionType.Left,
                DirectionType.Move,
                DirectionType.Left,
                DirectionType.Move,
                DirectionType.Left,
                DirectionType.Move,
                DirectionType.Left,
                DirectionType.Move,
                DirectionType.Move
            };
            MarsMap map = GetMap(1, 2, new NorthCardinalPoint(), directions);
            
            //act
            map.Discover();

            //assert
            Assert.AreEqual("1 3 N", map.ToString().Replace("\n", string.Empty));
        }
        
        [Test]
        public void Discover_WhenRoverIs3n3_2EPatternIsMMRMMRMRRM_ShouldLastPositionIs5_1_E()
        {
            //arrange
            var directions = new List<DirectionType>()
            {
                DirectionType.Move,
                DirectionType.Move,
                DirectionType.Right,
                DirectionType.Move,
                DirectionType.Move,
                DirectionType.Right,
                DirectionType.Move,
                DirectionType.Right,
                DirectionType.Right,
                DirectionType.Move
            };
            MarsMap map = GetMap(3, 3, new EastCardinalPoint(), directions);
            
            //act
            map.Discover();

            //assert
            Assert.AreEqual("5 1 E", map.ToString().Replace("\n", string.Empty));
        }
        
        private static MarsMap GetMap(int roverX, int roverY, ICardinalPoint cardinalPoint, List<DirectionType> directionTypes)
        {
            RoboticRover rover = new RoboticRover(new MarsPoint(roverX, roverY), cardinalPoint);
            var directions = directionTypes;
            rover.MovePattern = new MovePattern(directions);
            MarsMap map = new MarsMap(new MarsPoint(5, 5));
            map.Rovers = new List<RoverBase>() {rover};
            return map;
        }

    }

    public class RoverStub : RoverBase
    {
        public int MoveCalledCount { get; set; }

        public RoverStub(Point point, ICardinalPoint cardinalPoint) : base(point, cardinalPoint)
        {
        }

        internal override void MoveForward()
        {
        }

        internal override void TurnLeft()
        {
        }

        internal override void TurnRight()
        {
        }

        internal override void Move()
        {
            MoveCalledCount++;
        }
    }
}