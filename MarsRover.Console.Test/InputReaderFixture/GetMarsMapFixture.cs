using MarsRover.Core.Exception;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.Console.InputReaderFixture.Test
{
    [TestFixture]
    public class GetMarsMapFixture : InputReaderFixtureBase
    {
        [Test]
        public void GetMarsMap_WhenStringIsEmpty_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("");

            //act
            TestDelegate testDelegate = () => _inputReader.GetMarsMap();

            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }

        [Test]
        public void GetMarsMap_WhenStringLengthIsNot3_ShouldThrowException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("55");

            //act
            TestDelegate testDelegate = () => _inputReader.GetMarsMap();

            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }

        [Test]
        public void GetMarsMap_WhenSecondCharacterIsBotBlan_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("55 ");

            //act
            TestDelegate testDelegate = () => _inputReader.GetMarsMap();

            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetMarsMap_WhenInputIs5_5_ShouldToStringIsX_5_Y_5()
        {
            //arrange
            _consoleReader.ReadLine().Returns("5 5");

            //act
            var marsMap = _inputReader.GetMarsMap();

            //assert
            Assert.AreEqual("X: 5 Y: 5", marsMap.GetUpperRightCoordinate());
        }
    }
}