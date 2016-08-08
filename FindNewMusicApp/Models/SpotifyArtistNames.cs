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
    public class SpotifyArtistNames
    {
        public SpotifyArtistNames() { }
        public string band_name { get; set; }
       
        public string GetArtistNames(int i, string api_artist_names_url)
        {
            using (var w = new WebClient())
            {
                string api_uri = api_artist_names_url;
                String json_data = w.DownloadString(api_uri);
                var obj = JObject.Parse(json_data);
                var band_name = "";
                band_name = (string)obj.SelectToken("artists.[" + i + "].name");
            return band_name;
            }
        }

    }
}