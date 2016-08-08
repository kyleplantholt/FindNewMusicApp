using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindNewMusicApp.Models
{
    public class GetDistance
    {
        public GetDistance() { }

        public string api { get; set; }
        public string api_2 { get; set; }

        public string GetDistanceApi(string origin_address, string origin_city, string origin_state, string destination_address, string destination_city , string destination_state)
        {
            string api_pre = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial";
            string origin_pre = "&origins=";
            string origin_address1 = origin_address + " ";
            string origin_city1 = origin_city + ", ";
            string origin_state1 = origin_state + ", ";
            string destination_pre = "&destinations=";
            string destination_address1 = destination_address + " ";
            string destination_city1 = destination_city + ", ";
            string destination_state1 = destination_state;
            string api_key = "&key=AIzaSyAmtas2de7LDpypWmtui2z3jZLAFjd02Y4";


            string distance_api = api_pre + origin_pre + origin_address1 + origin_city1 + origin_state1 + destination_pre + destination_address1 + destination_city1 + destination_state1 + api_key;

            return distance_api;
        }

    }
}