using System;

namespace MarsRover.Core.Exception
{
    public class InputFormatException : UIException
    {
        public InputFormatException(string input) :
            base(input == String.Empty ? "String empty" : string.Format("'{0}' is not a valid format", input))
        {
            
        }
    }
}