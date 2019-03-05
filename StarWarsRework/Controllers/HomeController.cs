using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarWarsRework.Models;

namespace StarWarsRework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetStarWars()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://swapi.co/api/people/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject StarWarsJson = JObject.Parse(data);

            //
            List<JToken> people = StarWarsJson["results"].ToList();

            List<StartWarsChar> output = new List<StartWarsChar>();

            for(int i = 0; i < people.Count; i++)
            {
                StartWarsChar pr = new StartWarsChar();

                pr.Name = people[i]["name"].ToString();
                pr.HomeURL = people[i]["gender"].ToString();
                pr.SpeciesURL = people[i]["mass"].ToString();

                output.Add(pr);
            }

            //JToken people = StarWarsJson["results"][1]["name"];
            // string Name = people.ToString();

            ViewBag.DataShit = output;

            return View("StarWars");
            ////return View(output);
            //return View(Name);
        }

        
       //public ActionResult GetStarWars()
       // {
       //     HttpWebRequest WR = WebRequest.CreateHttp("https://swapi.co/api/people/1");
       //     HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();
       //     StreamReader data = new StreamReader(Response.GetResponseStream());
       //     string JsonData = data.ReadToEnd();
       //     JObject SWData = JObject.Parse(JsonData);
       //     ViewBag.Fact = SWData;
       //     return View("SearchResultsPage");
       // }

        public ActionResult StarWars()
        {
            return View();
        }

    }
}