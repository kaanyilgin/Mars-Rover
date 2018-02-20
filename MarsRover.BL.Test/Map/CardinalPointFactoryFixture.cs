using System;
using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class CardinalPointFactoryFixture
    {
        private CardinalPointFactory _factory;
        
        [SetUp]
        public void SetUp()
        {
            _factory = new CardinalPointFactory(); 
        }

        [Test]
        public void GetCardinalPoint_WhenCharIsN_ShouldNorthCardinalPointType()
        {
            //act
            ICardinalPoint cardinalPoint = _factory.GetCardinalPoint('N');
            
            //assert
            Assert.AreEqual(typeof(NorthCardinalPoint), cardinalPoint.GetType());
        }

        [Test]
        public void GetCardinalPoint_WhenCharIsE_ShouldEastCardinalPointType()
        {
            //act
            ICardinalPoint cardinalPoint = _factory.GetCardinalPoint('E');
            
            //assert
            Assert.AreEqual(typeof(EastCardinalPoint), cardinalPoint.GetType());
        }

        [Test]
        public void GetCardinalPoint_WhenCharIsN_ShouldSouthCardinalPointType()
        {
            //act
            ICardinalPoint cardinalPoint = _factory.GetCardinalPoint('S');
            
            //assert
            Assert.AreEqual(typeof(SouthCardinalPoint), cardinalPoint.GetType());
        }

        [Test]
        public void GetCardinalPoint_WhenCharIsW_ShouldWestCardinalPointType()
        {
            //act
            ICardinalPoint cardinalPoint = _factory.GetCardinalPoint('W');
            
            //assert
            Assert.AreEqual(typeof(WestCardinalPoint), cardinalPoint.GetType());
        }

        [Test]
        public void GetCardinalPoint_WhenCharIsL_ShouldThrowInvalidOperationException()
        {
            //act
            TestDelegate testDelegate = () => _factory.GetCardinalPoint('L');
            
            //assert
            Assert.Throws<InvalidOperationException>(testDelegate);
        }
    }
}