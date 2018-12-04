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
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns >AutoCompleteStringCollection</returns>
        public AutoCompleteStringCollection GetSuggestions(string query)
        {
            
            AutoCompleteStringCollection resColl = new AutoCompleteStringCollection();
            
            //If the Query used before is null or the new query doesn't Containt the old, make new API request.
            //It is used in that the API isn't called to many times.
            
           if (Query == null||!query.Contains(Query))
            {
                stations = transportAPI.GetStations(query);
                Query = query;
                foreach (Station s in stations.StationList)
                {
                    resColl.Add(s.Name);
                }
            }
            else
            {
                //If there was already a Query and the the new query conatins the Query requested before, 
                //the suggestions are taken from the local memory.
                foreach (Station s in stations.StationList)
                {
                    if(s.Name.ToUpper().Contains(query.ToUpper()))
                    {
                        resColl.Add(s.Name);
                    }
                }
            }


            return resColl;
        }

        public string GetStationLocation(string Station)
        {
            Stations stations = transportAPI.GetStations(Station);
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
                string[] items = { e.To, e.Stop.Departure.ToString("hh:mm"), e.Stop.Plattform };
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
        public ListViewItem[] GetConnections(string From, string To, DateTime DateTimeForConnections)
        {
            List<ListViewItem> results = new List<ListViewItem>();
            Connections currConns = transportAPI.GetConnections(From, To, DateTimeForConnections);
            foreach(Connection c in currConns.ConnectionList)
            {
                string[] items = { c.From.DateTimeDeparture.ToString("hh:mm"), c.To.DateTimeArrival.ToString("hh:mm"), c.DateTimeDuration.ToString("hh:mm"), c.From.Platform };
                results.Add(new ListViewItem(items));
            }

            return results.ToArray();
        }   
    }
}
