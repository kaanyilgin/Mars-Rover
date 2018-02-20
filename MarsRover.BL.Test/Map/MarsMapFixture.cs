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
        public void Discover_WhenTRoverOn4x4_ShouldRoverIsInMap()
        {
            //arrange 
            Point point = new MarsPoint(4, 4);
            ICardinalPoint cardinalPoint = new EastCardinalPoint();
            RoboticRover rover = new RoboticRover(point, cardinalPoint);
            MovePattern movePattern = new MovePattern(new List<DirectionType>()
            {
                DirectionType.Move
            });
            rover.MovePattern = movePattern;
            _map.Rovers = new List<RoverBase>()
            {
                rover
            };

            //act
            _map.Discover();

            //assert
            Assert.IsTrue(rover.InMap);
        }

        [Test]
        public void Discover_WhenTRoverOn5x5_ShouldRoverIsNotInMap()
        {
            //arrange 
            Point point = new MarsPoint(5, 5);
            ICardinalPoint cardinalPoint = new EastCardinalPoint();
            RoboticRover rover = new RoboticRover(point, cardinalPoint);
            MovePattern movePattern = new MovePattern(new List<DirectionType>()
            {
                DirectionType.Move
            });
            rover.MovePattern = movePattern;
            _map.Rovers = new List<RoverBase>()
            {
                rover
            };

            //act
            _map.Discover();

            //assert
            Assert.IsFalse(rover.InMap);
        }

        [Test]
        public void IsPointInMap_WhenMapIs5x5AndPointIs5x5_ShouldTrue()
        {
            //act
            bool isInMap = IsInMap(5, 5);

            //assert
            Assert.IsTrue(isInMap);
        }

        [Test]
        public void IsPointInMap_WhenMapIs5x5AndPointIs4x4_ShouldTrue()
        {
            //act
            bool isInMap = IsInMap(4, 4);

            //assert
            Assert.IsTrue(isInMap);
        }

        [Test]
        public void IsPointInMap_WhenMapIs5x5AndPointIs0x0_ShouldTrue()
        {
            //act
            bool isInMap = IsInMap(0, 0);

            //assert
            Assert.IsTrue(isInMap);
        }

        [Test]
        public void IsPointInMap_WhenMapIs5x5AndPointIs5x6_ShouldFalse()
        {
            //act
            bool isInMap = IsInMap(5, 6);

            //assert
            Assert.IsFalse(isInMap);
        }

        [Test]
        public void IsPointInMap_WhenMapIs5x5AndPointIs6x5_ShouldFalse()
        {
            //act
            bool isInMap = IsInMap(6, 5);

            //assert
            Assert.IsFalse(isInMap);
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

        private bool IsInMap(int x, int y)
        {
            //arrange
            Point point = new MarsPoint(x, y);

            //act
            return _map.IsPointInMap(point);
        }
    }

    public class RoverStub : RoverBase
    {
        public int MoveCalledCount { get; set; }

        public RoverStub()
        {
        }

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