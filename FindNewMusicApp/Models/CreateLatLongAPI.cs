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
    public class CreateLatLongAPI
    {
        public CreateLatLongAPI () { }



        public string api_3 { get; set; }
        public string city_from_input { get; set; }
        public string state_from_input { get; set; }


        public string MakeUri(string address_from_input, string city_from_input, string state_from_input)
        {
            string api_base = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string address = address_from_input;
            string pre_city = ",+";
            string city = city_from_input;
            string pre_state = ",+";
            string state = state_from_input;
            string apikey = "&key=AIzaSyA-MZhZuWjzvAzM3HdpjCJw0P1frncbm08";


            this.api_3 = api_base + address + pre_city + city + pre_state + state + apikey;


            return this.api_3;



        }
    }
}