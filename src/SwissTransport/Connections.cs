using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace SwissTransport
{
    public class Connections
    {
        [JsonProperty("connections")]
        public List<Connection> ConnectionList { get; set; } 
    }

    public class Connection
    {
        [JsonProperty("from")]
        public ConnectionPoint From  { get; set; }

        [JsonProperty("to")]
        public ConnectionPoint To { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }
        public DateTime DateTimeDuration { get; set; }

        public void ConverDur()
        {
            string[] durstring = Duration.Split('d');
            DateTimeDuration = Convert.ToDateTime(durstring[1]);
        }
    }

    public class ConnectionPoint
    {
        [JsonProperty("station")]
        public Station Station { get; set; }

        public string Arrival { get; set; }

        public DateTime DateTimeArrival { get; set; }

        public string ArrivalTimestamp { get; set; }

        public string Departure { get; set; }

        public DateTime DateTimeDeparture { get; set; }

        public string DepartureTimestamp { get; set; }

        public int? Delay { get; set; }

        public string Platform { get; set; }

        public string RealtimeAvailability { get; set; }


        public void ConvertToArrDep()
        {
            DateTimeArrival = Convert.ToDateTime(Arrival);
            DateTimeDeparture = Convert.ToDateTime(Departure);
        }
    }
}