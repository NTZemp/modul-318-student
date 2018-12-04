using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport
{
    public class StationNotFoundException : Exception
    {
        public StationNotFoundException()
        {

        }

        public StationNotFoundException(string message)
            :base(message)
        {
        }
        
    }
}
