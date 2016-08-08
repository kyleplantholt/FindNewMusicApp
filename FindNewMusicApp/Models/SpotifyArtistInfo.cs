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
    public class SpotifyArtistInfo
    {
        public SpotifyArtistInfo() { }
        public string band_name { get; set; }
        public int i { get; set; }

        public string[] GetPics(int i, string artist_api_search_url)
        {
            using (var w = new WebClient())
            {
                string api_uri = artist_api_search_url;
                String json_data = w.DownloadString(api_uri);
                var obj = JObject.Parse(json_data);
                string artist_image = (string)obj.SelectToken("artists.[" + i + "].images.[" + 0 + "].url");
                string artist_site = (string)obj.SelectToken("artists.[" + i + "].external_urls.spotify");
                return new string[] { artist_image, artist_site };
            }
        }
    }
}