using System.Collections;
using System.ComponentModel.Design;
using MarsRover.BL.Map;
using MarsRover.Core.Exception;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.Console.InputReaderFixture.Test
{
    [TestFixture]
    public class GetMovePatternFixture : InputReaderFixtureBase
    {
        [Test]
        public void GetRoverMovePattern_WhenStringIsR_L_ShouldThrowInputFormatException()
        {
            //arrange
            _consoleReader.ReadLine().Returns("R L");
            
            //act
            TestDelegate testDelegate = () => _inputReader.GetRoverMovePattern();
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }

        [Test]
        public void CheckLetters_WhenInputIsALR2_ShouldThrowInputFormatException()
        {
            //arrange
            string input = "ALR2";
            
            //act
            TestDelegate testDelegate = () => InputReader.CheckLetters(input);
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void CheckLetters_WhenInputIsALR_ShouldThrowInputFormatException()
        {
            //arrange
            string input = "ALR";
            
            //act
            TestDelegate testDelegate = () => InputReader.CheckLetters(input);
            
            //assert
            Assert.Throws<InputFormatException>(testDelegate);
        }
        
        [Test]
        public void CheckLetters_WhenInputIsLR_ShouldNotThrowInputFormatException()
        {
            //arrange
            string input = "LR";
            
            //act
            InputReader.CheckLetters(input);
        }
        
        [Test]
        public void CheckLetters_WhenInputIsLRM_ShouldNotThrowInputFormatException()
        {
            //arrange
            string input = "LMR";
            
            //act
            InputReader.CheckLetters(input);
        }
    }
}