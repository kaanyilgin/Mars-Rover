using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MarsRover.BL.Map;
using MarsRover.BL.Rover;
using MarsRover.Core.Exception;

namespace MarsRover.Console
{
    public class InputReader
    {
        private readonly IConsoleReader _consoleReader;
        private readonly ICardinalPointFactory _cardinalPointFactory;

        public InputReader(IConsoleReader consoleReader, ICardinalPointFactory cardinalPointFactory)
        {
            _consoleReader = consoleReader;
            _cardinalPointFactory = cardinalPointFactory;
        }

        public MarsMap GetMarsMap()
        {
            string mapSizeLine = _consoleReader.ReadLine();

            if (mapSizeLine.Length != 3 || mapSizeLine[1] != ' ')
            {
                throw new InputFormatException(mapSizeLine);
            }

            var point = GetMarsPoint(mapSizeLine);
            return new MarsMap(point);
        }

        public IList<RoverBase> GetRovers(int roverCount)
        {
            IList<RoverBase> rovers = new List<RoverBase>(roverCount);

            for (int i = 0; i < roverCount; i++)
            {
                RoverBase roverBase = GetRover();
                roverBase.MovePattern = GetRoverMovePattern();
                rovers.Add(roverBase);
            }

            return rovers;
        }

        public RoverBase GetRover()
        {
            string initialPosition = _consoleReader.ReadLine();

            if (initialPosition == string.Empty || initialPosition.Length != 5 || initialPosition[1] != ' ' ||
                initialPosition[3] != ' ')
            {
                throw new InputFormatException("String empty");
            }

            var coordinateString = GetCoordinatesFromRoversInitialPoint(initialPosition);
            Point point = GetMarsPoint(coordinateString);
            var cardinalPointChar = initialPosition[4];
            ICardinalPoint cardinalPoint = _cardinalPointFactory.GetCardinalPoint(cardinalPointChar);

            return new RoboticRover(point, cardinalPoint);
        }

        internal static string GetCoordinatesFromRoversInitialPoint(string initialPosition)
        {
            string coordinateString = initialPosition.Substring(0, 3);
            return coordinateString;
        }

        //internal for test purpose
        internal static Point GetMarsPoint(string mapSizeLine)
        {
            IList<int> coordinates;

            try
            {
                coordinates = mapSizeLine.Split(' ').Select(c => int.Parse(c)).ToList();
            }
            catch (FormatException)
            {
                throw new InputFormatException(mapSizeLine);
            }

            var x = coordinates[0];
            var y = coordinates[1];
            Point point = new MarsPoint(x, y);
            return point;
        }

        public MovePattern GetRoverMovePattern()
        {
            var movePatternLine = _consoleReader.ReadLine().Trim();

            if (movePatternLine.Contains(' '))
            {
                throw new InputFormatException(movePatternLine);
            }

            CheckLetters(movePatternLine);

            IList<DirectionType> movePattern = new List<DirectionType>();

            foreach (var direction in movePatternLine)
            {
                DirectionType type = DirectionType.Right;

                switch (direction)
                {
                    case 'R':
                        type = DirectionType.Right;
                        break;
                    case 'L':
                        type = DirectionType.Right;
                        break;
                    case 'M':
                        type = DirectionType.Move;
                        break;
                }

                movePattern.Add(type);
            }

            return new MovePattern(movePattern);
        }

        internal static void CheckLetters(string movePatternLine)
        {
            string regexPattern = @"^[LRM]+$";

            var isMatched = Regex.IsMatch(movePatternLine, regexPattern);

            if (isMatched == false)
            {
                throw new InputFormatException(movePatternLine);
            }
        }
    }
}