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

        public ListViewItem[] GetConnections(string From, string To)
        {
            List<ListViewItem> results = new List<ListViewItem>();
            Connections currConns = transportAPI.GetConnections(From, To);
            foreach(Connection c in currConns.ConnectionList)
            {
                string[] items = { c.From.Departure, c.To.Arrival, c.Duration, c.From.Platform };
                results.Add(new ListViewItem(items));
            }

            return results.ToArray();
        }   
    }
}
