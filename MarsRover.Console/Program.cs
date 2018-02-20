using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using MarsRover.BL.Map;
using MarsRover.BL.Rover;

namespace MarsRover.Console
{
    class Program
    {
        private static int roverCount = 2;

        public static void Main(string[] args)
        {
            IConsoleReader consoleReader = new SystemConsoleReader();
            ICardinalPointFactory cardinalPointFactory = new CardinalPointFactory();
            InputReader InputReader = new InputReader(consoleReader, cardinalPointFactory);
            MarsMap marsMap = InputReader.GetMarsMap();
            IList<RoverBase> rovers = InputReader.GetRovers(roverCount);
            marsMap.Rovers = rovers;
            marsMap.Discover();
            var roversPositions = marsMap.ToString();
            System.Console.WriteLine(roversPositions);
        }
    }
}