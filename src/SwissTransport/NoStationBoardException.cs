using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport
{
    public class NoStationBoardException:Exception
    {
        public NoStationBoardException()
        {

        }
        public  NoStationBoardException(string message)
            : base(message)
        {

        }
    }
}
