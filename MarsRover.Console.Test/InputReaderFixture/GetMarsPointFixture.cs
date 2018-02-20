using MarsRover.Core.Exception;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.Console.InputReaderFixture.Test
{
    [TestFixture]
    public class GetMarsPointFixture : InputReaderFixtureBase
    {
        [Test]
        public void GetMarsPoint_WhenThereIsAlfaNumericCharacterInInput_ShouldThrowInputFormatException()
        {
            //arrange
            string coordinateLine = "A A";

            //act
            TestDelegate testDelegate = () => InputReader.GetMarsPoint(coordinateLine);

            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }

        [Test]
        public void GetMarsPoint_WhenInputIs5_5_ShouldToStringIsX_5_Y_5()
        {
            //arrange
            string coordinateLine = "5 5";

            //act
            var marsPoint = InputReader.GetMarsPoint(coordinateLine);

            //assert
            Assert.AreEqual("X: 5 Y: 5", marsPoint.ToString());
        }
    }
}