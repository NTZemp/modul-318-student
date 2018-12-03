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


        public AutoCompleteStringCollection GetSuggestions(string query)
        {
            AutoCompleteStringCollection resColl = new AutoCompleteStringCollection();
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

        public ListViewItem[] GetStationBoard(string Station)
        {
            string id = transportAPI.GetStations(Station).StationList[1].Id;
            List<ListViewItem> results = new List<ListViewItem>();
            StationBoardRoot stationBoard = transportAPI.GetStationBoard(Station, id);
            foreach (StationBoard e in stationBoard.Entries)
            {
                string[] items = { e.To, e.Stop.Departure.ToString("hh:mm"), e.Stop.Plattform };
                results.Add(new ListViewItem(items));
            }
            return results.ToArray();
        }


        public ListViewItem[] GetConnections(string From, string To)
        {
            List<ListViewItem> results = new List<ListViewItem>();
            Connections currConns = transportAPI.GetConnections(From, To);
            foreach(Connection c in currConns.ConnectionList)
            {
                string[] items = { c.From.DateTimeDeparture.ToString("hh:mm"), c.To.DateTimeArrival.ToString("hh:mm"), c.DateTimeDuration.ToString("hh:mm"), c.From.Platform };
                results.Add(new ListViewItem(items));
            }

            return results.ToArray();
        }   
    }
}
