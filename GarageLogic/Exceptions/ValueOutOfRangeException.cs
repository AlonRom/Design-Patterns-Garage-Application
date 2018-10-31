using System;

namespace GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {
        }
    }
}
