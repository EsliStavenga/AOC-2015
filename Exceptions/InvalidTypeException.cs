using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Exceptions
{
    class InvalidTypeException : Exception
    {

        public InvalidTypeException(string exception) : base(exception)
        {

        }
    }
}
