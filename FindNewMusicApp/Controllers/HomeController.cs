using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindNewMusicApp.Models;

namespace FindNewMusicApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Results()
        {

            string artist_from_input = Request.Form["artist"];
            string city_from_input = Request.Form["city"];
            string state_from_input = Request.Form["state"];
            string zipcode_from_input = Request.Form["zipcode"];
            string address_from_input = Request.Form["address"];


            //Get API for LAT&LONG
            CreateLatLongAPI createlatlongapi = new CreateLatLongAPI();
            string longlat_api_uri = createlatlongapi.MakeUri(address_from_input, city_from_input, state_from_input);

            //Parse for LatLong
            ParseLongLat parselonglat = new ParseLongLat();
            string[] latlong = new string[2];
            latlong = parselonglat.LongLatParser(longlat_api_uri);


            //Create Artist ID Search URL
            GetBands getbands = new GetBands();
                string api_artist_id_search_uri = getbands.GetArtistID(artist_from_input);
            //Parse & Return Artist ID
                SpotifyArtistID spotifyartistid = new SpotifyArtistID();
                string api_spotify_artist_id = spotifyartistid.GetArtistID(api_artist_id_search_uri);
            //Parse For Artist Name
                ParseForSearchedArtist parseforsearchedartist = new ParseForSearchedArtist();
                string api_spotify_searched_artist = parseforsearchedartist.GetArtistName(api_artist_id_search_uri);
            //Create Similar Artist Search URL
            GetBands getartists = new GetBands();
                string api_artist_names_url = getbands.GetArtistNames(api_spotify_artist_id);
            //Parse For Similar Artists
                 SpotifyArtistNames spotifyartistnames = new SpotifyArtistNames();
                 string[] api_spotify_artist_names = new string[7];
                 for (int i = 0; i < 7; i++) {
                    api_spotify_artist_names[i] = spotifyartistnames.GetArtistNames(i, api_artist_names_url);
                    }
            //Create Similar Artist Shows Search URLs
                GetShows getshows = new GetShows(artist_from_input);
                string[] artist_api_search_url = new string[7];
                for (int i = 0; i < 7; i++)
                {
                artist_api_search_url[i] = getshows.GetShowInfo(api_spotify_artist_names[i], city_from_input, state_from_input, latlong[0], latlong[1]);
                }
            //Create Searched Artist Show Search URL
                GetShows getshows2 = new GetShows(artist_from_input);
                string searched_artist_api_url = getshows2.GetShowInfo(api_spotify_searched_artist, city_from_input, state_from_input, latlong[0], latlong[1]);


            //Parse Show #1
            TicketmasterShows ticketmastershows = new TicketmasterShows();
                string[] api_ticketmaster_show_1 = new string[9];
                api_ticketmaster_show_1 = ticketmastershows.GetTMInfo(artist_api_search_url[0]);
            //Parse Show #2
                TicketmasterShows ticketmastershows2 = new TicketmasterShows();
                string[] api_ticketmaster_show_2 = new string[9];
                api_ticketmaster_show_2 = ticketmastershows.GetTMInfo(artist_api_search_url[1]);
            //Parse Show #3
           // TicketmasterShows ticketmastershows3 = new TicketmasterShows();
                string[] api_ticketmaster_show_3 = new string[9];
                api_ticketmaster_show_3 = ticketmastershows.GetTMInfo(artist_api_search_url[2]);
            //Parse Show #4
            TicketmasterShows ticketmastershows4 = new TicketmasterShows();
                string[] api_ticketmaster_show_4 = new string[9];
                api_ticketmaster_show_4 = ticketmastershows.GetTMInfo(artist_api_search_url[3]);
            //Parse Show #5
            TicketmasterShows ticketmastershows5 = new TicketmasterShows();
                string[] api_ticketmaster_show_5 = new string[9];
                api_ticketmaster_show_5 = ticketmastershows.GetTMInfo(artist_api_search_url[4]);
            //Parse Show #6
            TicketmasterShows ticketmastershows6 = new TicketmasterShows();
                string[] api_ticketmaster_show_6 = new string[9];
                api_ticketmaster_show_6 = ticketmastershows2.GetTMInfo(artist_api_search_url[5]);
            //Parse Show #7
                TicketmasterShows2 ticketmastershows7 = new TicketmasterShows2();
                string[] api_ticketmaster_show_7 = new string[9];
                api_ticketmaster_show_7 = ticketmastershows7.GetTMInfo2(artist_api_search_url[0]);
            //Parse Show #8
                TicketmasterShows2 ticketmastershows8 = new TicketmasterShows2();
                string[] api_ticketmaster_show_8 = new string[9];
                api_ticketmaster_show_8 = ticketmastershows8.GetTMInfo2(artist_api_search_url[1]);
            //Parse Show #9
                TicketmasterShows2 ticketmastershows9 = new TicketmasterShows2();
                string[] api_ticketmaster_show_9 = new string[9];
                api_ticketmaster_show_9 = ticketmastershows9.GetTMInfo2(artist_api_search_url[2]);
            //Parse Show #10
                TicketmasterShows2 ticketmastershows10 = new TicketmasterShows2();
                string[] api_ticketmaster_show_10 = new string[9];
                api_ticketmaster_show_10 = ticketmastershows10.GetTMInfo2(artist_api_search_url[3]);
            //Parse Show #11
                TicketmasterShows2 ticketmastershows11 = new TicketmasterShows2();
                string[] api_ticketmaster_show_11 = new string[9];
                api_ticketmaster_show_11 = ticketmastershows11.GetTMInfo2(artist_api_search_url[4]);
            //Parse Show #12
                TicketmasterShows2 ticketmastershows12 = new TicketmasterShows2();
                string[] api_ticketmaster_show_12 = new string[9];
                api_ticketmaster_show_12 = ticketmastershows12.GetTMInfo2(artist_api_search_url[5]);
            //Parse Show #13
                TicketmasterShows ticketmastershows13 = new TicketmasterShows();
                string[] api_ticketmaster_show_13 = new string[9];
                api_ticketmaster_show_13 = ticketmastershows13.GetTMInfo(searched_artist_api_url);
            //Parse Show #14
                TicketmasterShows2 ticketmastershows14 = new TicketmasterShows2();
                string[] api_ticketmaster_show_14 = new string[9];
                api_ticketmaster_show_14 = ticketmastershows14.GetTMInfo2(searched_artist_api_url);

            string[][] api_ticketmaster_show_ALL = new string[][] {
                api_ticketmaster_show_1,
                api_ticketmaster_show_2,
                api_ticketmaster_show_3,
                api_ticketmaster_show_4,
                api_ticketmaster_show_5,
                api_ticketmaster_show_6,
                api_ticketmaster_show_7,
                api_ticketmaster_show_8,
                api_ticketmaster_show_9,
                api_ticketmaster_show_10,
                api_ticketmaster_show_11,
                api_ticketmaster_show_12,
                api_ticketmaster_show_13,
                api_ticketmaster_show_14,
            };

            string temp_show_item = api_ticketmaster_show_ALL[1][4];


            //Get Artist Photos & Site Addresses
            SpotifyArtistInfo spotifyartistinfo = new SpotifyArtistInfo();

            string[][] artist_pics_sites_ALL = new string[6][];

            for(int i=0; i<6; i++)
            {
                artist_pics_sites_ALL[i] = spotifyartistinfo.GetPics(i, api_artist_names_url);
            }


            GetDistance getdistance = new GetDistance();
            string[] distance_api_search_url_ALL = new string[14];

            for(int i = 0; i<14; i++)
            {
                distance_api_search_url_ALL[i] = getdistance.GetDistanceApi(address_from_input, city_from_input, state_from_input, api_ticketmaster_show_ALL[i][6], api_ticketmaster_show_ALL[i][4], api_ticketmaster_show_ALL[i][5]);
            }


            GoogleMaps googlemaps = new GoogleMaps();

            string[] miles_away_ALL = new string[14];

            for(int i=0; i<14; i++)
            {
                miles_away_ALL[i] = googlemaps.ParseDistance(distance_api_search_url_ALL[i]);
            }


            List<string> list1 = new List<string>();
            list1.Add(ViewBag.api_spotify_artist = api_spotify_artist_id);

            ViewBag.distance_api_search_url_1 = distance_api_search_url_ALL[0];
            //ViewBag.distance_api_search_url_1 = distance_api_search_url_1;

            ViewBag.artist_pics_sites_0 = artist_pics_sites_ALL[0];
            ViewBag.artist_pics_sites_1 = artist_pics_sites_ALL[1];
            ViewBag.artist_pics_sites_2 = artist_pics_sites_ALL[2];
            ViewBag.artist_pics_sites_3 = artist_pics_sites_ALL[3];
            ViewBag.artist_pics_sites_4 = artist_pics_sites_ALL[4];
            ViewBag.artist_pics_sites_5 = artist_pics_sites_ALL[5];
            ViewBag.miles_away_0 = miles_away_ALL[0];
            ViewBag.miles_away_1 = miles_away_ALL[1];
            ViewBag.miles_away_2 = miles_away_ALL[2];
            ViewBag.miles_away_3 = miles_away_ALL[3];
            ViewBag.miles_away_4 = miles_away_ALL[4];
            ViewBag.miles_away_5 = miles_away_ALL[5];
            ViewBag.miles_away_6 = miles_away_ALL[6];
            ViewBag.miles_away_7 = miles_away_ALL[7];
            ViewBag.miles_away_8 = miles_away_ALL[8];
            ViewBag.miles_away_9 = miles_away_ALL[9];
            ViewBag.miles_away_10 = miles_away_ALL[10];
            ViewBag.miles_away_11 = miles_away_ALL[11];
            ViewBag.miles_away_12 = miles_away_ALL[12];
            ViewBag.miles_away_13 = miles_away_ALL[13];
            ViewBag.distance_api_search_url_2 = distance_api_search_url_ALL[1];
            ViewBag.distance_api_search_url_3 = distance_api_search_url_ALL[2];
            ViewBag.distance_api_search_url_4 = distance_api_search_url_ALL[3];
            ViewBag.distance_api_search_url_5 = distance_api_search_url_ALL[4];
            ViewBag.distance_api_search_url_6 = distance_api_search_url_ALL[5];
            ViewBag.artist_from_input = artist_from_input;
            ViewBag.api_artist_id = api_artist_id_search_uri;
            ViewBag.api_artist_names_url = api_artist_names_url;
            ViewBag.api_show_info = api_ticketmaster_show_1;
            ViewBag.mylist = list1;
            ViewBag.artist_api_search_url = artist_api_search_url;
            ViewBag.api_spotify_artist = api_spotify_artist_id;
            ViewBag.api_spotify_artist_names = api_spotify_artist_names;
            ViewBag.api_ticketmaster_show_1 = api_ticketmaster_show_1;
            ViewBag.api_ticketmaster_show_2 = api_ticketmaster_show_2;
            ViewBag.api_ticketmaster_show_3 = api_ticketmaster_show_3;
            ViewBag.api_ticketmaster_show_4 = api_ticketmaster_show_4;
            ViewBag.api_ticketmaster_show_5 = api_ticketmaster_show_5;
            ViewBag.api_ticketmaster_show_6 = api_ticketmaster_show_6;
            ViewBag.api_ticketmaster_show_7 = api_ticketmaster_show_7;
            ViewBag.api_ticketmaster_show_8 = api_ticketmaster_show_8;
            ViewBag.api_ticketmaster_show_9 = api_ticketmaster_show_9;
            ViewBag.api_ticketmaster_show_10 = api_ticketmaster_show_10;
            ViewBag.api_ticketmaster_show_11 = api_ticketmaster_show_11;
            ViewBag.api_ticketmaster_show_12 = api_ticketmaster_show_12;
            ViewBag.api_ticketmaster_show_13 = api_ticketmaster_show_13;
            ViewBag.api_ticketmaster_show_14 = api_ticketmaster_show_14;
            ViewBag.api_spotify_searched_artist = api_spotify_searched_artist;
            ViewBag.searched_artist_api_url = searched_artist_api_url;
            ViewBag.artist_from_input = artist_from_input;
            ViewBag.city_from_input = city_from_input;
            ViewBag.state_from_input = state_from_input;
            ViewBag.zipcode_from_input = zipcode_from_input;
            ViewBag.address_from_input = address_from_input;
            ViewBag.latlong0 = latlong[0];
            ViewBag.latlong1 = latlong[1];


            return View("Results");

            }

            }

        }

