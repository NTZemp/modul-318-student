using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEV_APP_UI
{
    public class NoLocationDataException : Exception
    {
        public NoLocationDataException()
        {

        }

        public NoLocationDataException(string message)
            : base(message)
        {

        }
    }
}
