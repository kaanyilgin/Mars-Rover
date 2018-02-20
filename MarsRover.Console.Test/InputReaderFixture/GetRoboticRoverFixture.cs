using MarsRover.BL.Rover;
using MarsRover.Core.Exception;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.Console.InputReaderFixture.Test
{
    [TestFixture]
    public class GetRoboticRoverFixture : InputReaderFixtureBase
    {
        [Test]
        public void GetRoboticRover_WhenStringIsEmpty_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns(""); 
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRover();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetRoboticRover_WhenStringLengthIsNot5_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("1 2 N 3"); 
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRover();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetRoboticRover_WhenSecondCharacterIsNotBlank_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("12 N "); 
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRover();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetRoboticRover_WhenForthCharacterIsNotBlank_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("1 2N "); 
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRover();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetRoboticRover_WhenForthCharacterIsNotBlank_Should()
        {
            //arrange
            _consoleReader.ReadLine().Returns("1 2N "); 
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRover();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void GetRoboticRover_WhenInitialPointIs1_2_N_ShouldCoordinateLineIs1_2()
        {
            //arrange
            string initalPoint = "1 2 N"; 
            
            //act
            string coordinatesLine = InputReader.GetCoordinatesFromRoversInitialPoint(initalPoint);
            
            //assert
            Assert.AreEqual("1 2",coordinatesLine);
        }
        
        [Test]
        public void GetRoboticRover_WhenInitialPointIs1_2_N_ShouldGetCardinalPointCallsOnceWithN()
        {
            //arrange
            _consoleReader.ReadLine().Returns("1 2 N"); 
            
            //act
            RoverBase roverBase = _inputReader.GetRover();
            
            //assert
            _cardinalPointFactory.Received(1).GetCardinalPoint('N');
        }
    }
}