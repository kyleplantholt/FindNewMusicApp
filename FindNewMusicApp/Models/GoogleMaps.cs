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
    public class GoogleMaps
    {
        public GoogleMaps() { }

        public string band_name { get; set; }

        public string ParseDistance(string distance_url)
        {
             using (var w = new WebClient())
            {
               string uri = distance_url;
               String json_data = w.DownloadString(uri);
               var obj = JObject.Parse(json_data);
               var miles = "";
               miles = (string)obj.SelectToken("rows.[" + 0 + "].elements.[" + 0 + "].distance.text");

               return miles;
                }
            }
    }
}