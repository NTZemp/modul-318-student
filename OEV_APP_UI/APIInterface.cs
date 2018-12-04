using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace OEV_APP_UI
{
    class APIInterface
    {
        public Transport transportAPI = new Transport();
        private Stations stations;
        private string Query;

        /// <summary>
        /// This Method provides Station suggestions while Typing
        /// </summary>
        /// <param name="query"></param>
        /// <returns >AutoCompleteStringCollection</returns>
        public AutoCompleteStringCollection GetSuggestions(string query)
        {
            
            AutoCompleteStringCollection resColl = new AutoCompleteStringCollection();
            stations = transportAPI.GetStations(query);
            Query = query;
            foreach (Station s in stations.StationList)
            {
                resColl.Add(s.Name);
            }



            return resColl;
        }

        public string GetStationLocation(string Station)
        {
            Stations stations = transportAPI.GetStations(Station);
            if(stations.StationList[0].Coordinate.XCoordinate == null)
            {
                throw new NoLocationDataException($"Für die Station {Station} sind leider keine Standortdaten verfügbar");
            }
            string xy = stations.StationList[0].Coordinate.XCoordinate.ToString().Replace(',', '.')+"," + stations.StationList[0].Coordinate.YCoordinate.ToString().Replace(',', '.');
            return xy;
        }


        /// <summary>
        /// Gets the StationBoard from Station as ListViewItemArray 
        /// </summary>
        /// <param name="Station"></param>
        /// <returns>ListViewItem[]</returns>
        public ListViewItem[] GetStationBoard(string Station)
        {
            string id = transportAPI.GetStations(Station).StationList[0].Id;
            List<ListViewItem> results = new List<ListViewItem>();
            StationBoardRoot stationBoard = transportAPI.GetStationBoard(Station, id);
            foreach (StationBoard e in stationBoard.Entries)
            {
                string[] items = { e.To, e.Stop.Departure.ToString("hh:mm"), e.Stop.Plattform == null ? "K/A" : e.Stop.Plattform };
                results.Add(new ListViewItem(items));
            }
            return results.ToArray();
        }

        /// <summary>
        /// Gets Connections from the From Station, the To Station and the Date as ListViewItemArray
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="DateTimeForConnections"></param>
        /// <returns></returns>
        public ListViewItem[] GetConnections(string From, string To, DateTime DateTimeForConnections, bool AbOrAn)
        {
            string AnOrAb ="0" ;
            if (AbOrAn)
            {
                AnOrAb = "1";
            }
            List<ListViewItem> results = new List<ListViewItem>();
            Connections currConns = transportAPI.GetConnections(From, To, DateTimeForConnections, AnOrAb);
            foreach(Connection c in currConns.ConnectionList)
            {
                string[] items = { c.From.DateTimeDeparture.ToString("HH:mm"), c.To.DateTimeArrival.ToString("HH:mm") , c.DateTimeDuration.ToString("HH:mm") , c.From.Platform };
                results.Add(new ListViewItem(items));
            }

            return results.ToArray();
        }   
    }
}
