using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport
{
    public class NoConnectionException : Exception
    {
        public NoConnectionException()
        {

        }

        public NoConnectionException(string message)
            : base(message)
        {
        }
    }
}
