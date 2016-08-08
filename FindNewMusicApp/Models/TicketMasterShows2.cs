using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FindNewMusicApp.Models
{
    public class TicketmasterShows2
    {
        public TicketmasterShows2() { }
        public string band_name { get; set; }
        public string band_name_2 { get; set; }
        public string show_date { get; set; }


        public string[] GetTMInfo2(string artist_api_search_url)
        {
            using (var w = new WebClient())
            {

                string api_uri = artist_api_search_url;
                String json_data = w.DownloadString(api_uri);
                var obj = JObject.Parse(json_data);
                string artist_name = (string)obj.SelectToken("_embedded.events.[" + 2 + "].name");
                string show_date = (string)obj.SelectToken("_embedded.events.[" + 2 + "].dates.start.localDate");
                string show_time = (string)obj.SelectToken("_embedded.events.[" + 2 + "].dates.start.localTime");
                string venue_name = (string)obj.SelectToken("_embedded.events.[" + 2 + "]._embedded.venues.[" + 0 + "].name");
                string city_name = (string)obj.SelectToken("_embedded.events.[" + 2 + "]._embedded.venues.[" + 0 + "].city.name");
                string state_name = (string)obj.SelectToken("_embedded.events.[" + 2 + "]._embedded.venues.[" + 0 + "].state.name");
                string address = (string)obj.SelectToken("_embedded.events.[" + 2 + "]._embedded.venues.[" + 0 + "].address.line1");
                string ticket_uri = (string)obj.SelectToken("_embedded.events.[" + 2 + "].url");
                string sale_status = (string)obj.SelectToken("_embedded.events.[" + 2 + "].dates.status.code");

                Show show = new Show();
                show.band = artist_name;
                // return show;

                return new string[] { artist_name, show_date, show_time, venue_name, city_name, state_name, address, ticket_uri, sale_status };
            }
        }
    }
}