using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SwissTransport
{
    public class Transport : ITransport
    {

        /// <summary>
        /// Asks Transport API for all Stations with query in the name
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Returns a Stations object with all the Stations returned by the API</returns>
        public Stations GetStations(string query)
        {
            var request = CreateWebRequest("http://transport.opendata.ch/v1/locations?query=" + query);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var message = new StreamReader(responseStream).ReadToEnd();
                var stations = JsonConvert.DeserializeObject<Stations>(message
                    , new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return stations;
            }

            return null;
        }

        /// <summary>
        /// Gets the Station identified by the Id and Station Name
        /// </summary>
        /// <param name="station"></param>
        /// <param name="id"></param>
        /// <returns>Returns a Stationboard object</returns>
        public StationBoardRoot GetStationBoard(string station, string id)
        {
            var request = CreateWebRequest("http://transport.opendata.ch/v1/stationboard?Station=" + station);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var stationboard =
                    JsonConvert.DeserializeObject<StationBoardRoot>(readToEnd);
                return stationboard;
            }

            return null;
        }

        public Connections GetConnections(string fromStation, string toStattion)
        {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/connections?from=" + fromStation + "&to=" + toStattion);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();



                if (responseStream != null)
                {
                    var readToEnd = new StreamReader(responseStream).ReadToEnd();
                    var connections =
                        JsonConvert.DeserializeObject<Connections>(readToEnd);
                    Convert(ref connections);
                    return connections;
                }

            return null;
        }


        public Connections GetConnections(string fromStation, string toStation, DateTime time)
        {
            string requestString = $"http://transport.opendata.ch/v1/connections?from={fromStation}&to={toStation}";
            var request = CreateWebRequest(requestString + time.ToString("hh:mm")+ "&date" + time.Date.ToString("YYYY-MM-DD"));
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var connections =
                    JsonConvert.DeserializeObject<Connections>(readToEnd);
                Convert(ref connections);
                return connections;
            }

            return null;
        }

        public void Convert( ref Connections connections)
        {
            foreach (Connection c in connections.ConnectionList)
            {
                c.ConverDur();
                c.From.ConvertToArrDep();
                c.To.ConvertToArrDep();
            }
        }


        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;

            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            
            return request;
        }
    }
}
