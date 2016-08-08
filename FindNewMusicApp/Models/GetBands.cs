using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FindNewMusicApp.Controllers;
using FindNewMusicApp.Models;

namespace FindNewMusicApp.Models
{
    public class GetBands
    {
        public GetBands()  { }

        public string api { get; set; }
        public string api_2 { get; set; }

        public string GetArtistID(string artist)
        {
            string api_key_part_1_1 = "https://api.spotify.com/v1/search?q=";
            string api_key_part_2_1 = artist;
            string api_key_part_3_1 = "&type=artist";
            this.api = api_key_part_1_1 + api_key_part_2_1 + api_key_part_3_1;
            return this.api;
        }

        public string GetArtistNames(string artist_id)
        {
            string api_key_part_1_2 = "https://api.spotify.com/v1/artists/";
            string api_key_part_2_2 = artist_id;
            string api_key_part_3_2 = "/related-artists";
            this.api_2 = api_key_part_1_2 + api_key_part_2_2 + api_key_part_3_2;
            return this.api_2;

        }

        //connect spotify


        //return api


        //parse json


    }
}