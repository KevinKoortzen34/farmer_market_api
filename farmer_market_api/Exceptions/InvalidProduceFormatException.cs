using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmer_market_api.Exceptions
{
    public class InvalidProduceFormatException : Exception
    {
        public InvalidProduceFormatException(){}

        public InvalidProduceFormatException(string message) : base(message)
        {
        }
    }
}