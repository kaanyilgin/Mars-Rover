using MarsRover.BL.Map;
using NUnit.Framework;

namespace MarsRover.BL.Test.Map
{
    [TestFixture]
    public class PointFixture
    {
        private MarsPoint _marsPoint;

        [SetUp]
        public void SetUp()
        {
            _marsPoint = new MarsPoint(0, 0);
        }

        [Test]
        public void PointIncrementX_WhenXIs0_ShouldXIs1()
        {
            //act
            _marsPoint.IncrementX();
            
            //assert
            Assert.AreEqual(1, _marsPoint.X);
        }

        [Test]
        public void PointDecrementX_WhenXIs0_ShouldXIsMinus1()
        {
            //act
            _marsPoint.DecrementX();
            
            //assert
            Assert.AreEqual(-1, _marsPoint.X);
        }

        [Test]
        public void PointIncrementY_WhenYIs0_ShouldYIs1()
        {
            //act
            _marsPoint.IncrementY();
            
            //assert
            Assert.AreEqual(1, _marsPoint.Y);
        }

        [Test]
        public void PointDecrementY_WhenYIs0_ShouldYIsMinus1()
        {
            //act
            _marsPoint.DecrementY();
            
            //assert
            Assert.AreEqual(-1, _marsPoint.Y);
        }
    }
}