namespace MarsRover.Console
{
    class SystemConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}