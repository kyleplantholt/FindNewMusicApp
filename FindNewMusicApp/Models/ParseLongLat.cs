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
    public class ParseLongLat
    {
        public ParseLongLat() { }

        public string band_name { get; set; }


        public string[] LongLatParser(string longlat_api_uri)
        {
            using (var w = new WebClient())
            {
                string uri = longlat_api_uri;
                String json_data = w.DownloadString(uri);
                var obj = JObject.Parse(json_data);
                string lat = (string)obj.SelectToken("results.[0].geometry.location.lat");
                string lng = (string)obj.SelectToken("results.[0].geometry.location.lng");

                return new string[] { lat, lng };

            }
        }
    }
}
