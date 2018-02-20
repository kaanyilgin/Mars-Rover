using MarsRover.BL.Map;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.Console.InputReaderFixture.Test
{
    public class InputReaderFixtureBase
    {
        internal IConsoleReader _consoleReader;
        internal InputReader _inputReader;
        internal ICardinalPointFactory _cardinalPointFactory;

        [SetUp]
        public virtual void SetUp()
        {
            _consoleReader = Substitute.For<IConsoleReader>();
            _cardinalPointFactory = Substitute.For<ICardinalPointFactory>();
            _inputReader = new InputReader(_consoleReader,_cardinalPointFactory);
        }
    }
}