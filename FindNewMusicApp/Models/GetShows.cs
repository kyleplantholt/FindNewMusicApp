using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;



namespace FindNewMusicApp.Models
{
    public class GetShows
    {
        public GetShows(string artist_from_input) { }



        public string api_3 { get; set; }
        public string city_from_input { get; set; }
        public string state_from_input { get; set; }


        public string GetShowInfo (string api_spotify_artist_name, string city_from_input, string state_from_input, string lat, string lng)
        {
            string api_base = "https://app.ticketmaster.com/discovery/v2/events.json?";
            string keyword_pre = "keyword=";
            string keyword = api_spotify_artist_name;

            string latlong_pre = "&latlong=";
            string lat1 = lat;
            string latlong_mid = ",";
            string long1 = lng;
            string radius_pre = "&radius=";
            string radius = "50";
            string unit_pre = "&unit=";
            string unit = "miles";
            string api_key_pre = "&apikey=";
            string api_key = "9wpBYS3VYODSP1ksTqeM0zi6wsOddsZo";
            this.api_3 = api_base + keyword_pre + keyword +  latlong_pre + lat1 + latlong_mid + long1 + radius_pre + radius + unit_pre + unit + api_key_pre + api_key;


            return this.api_3;



        }





    }
}