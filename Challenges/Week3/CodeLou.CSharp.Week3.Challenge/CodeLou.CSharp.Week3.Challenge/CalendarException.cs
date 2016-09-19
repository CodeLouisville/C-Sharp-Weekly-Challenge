using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    class CalendarException : System.Exception
    {
        public CalendarException()
            {
     
            }
        public CalendarException(string message) : base(message)
            {

            }
    }

    class OutOfBoundsException : CalendarException
    {
        public OutOfBoundsException()
        {

        }

        public OutOfBoundsException(string message) : base(message)
        {

        }
    }
}