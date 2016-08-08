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
    public class SpotifyArtistID
    {
        public SpotifyArtistID() { }
        public string band_name { get; set; }

        public string GetArtistID(string artist_search_uri)
        {
            using (var w = new WebClient())
            {
                string uri = artist_search_uri;
                String json_data = w.DownloadString(uri);
                var obj = JObject.Parse(json_data);
                var artist_id = "";
                artist_id = (string)obj.SelectToken("artists.items.[" + 0 + "].id");
                return artist_id;
                }
            }

        }
    }


