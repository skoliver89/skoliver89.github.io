using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GiphySearch.Controllers
{
    public class GiphyController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public JsonResult Search(int? page = 1)
        {
            //Giphy API params
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"]; //retrieve the key from a secret place
            string q = Request.QueryString["q"]; //the user's search string
            string rating = Request.QueryString["rating"]; //desired max msrp rating
            string lang = Request.QueryString["lang"]; //language selected, for localization purposes

            //Pagination Params - the page variable is from the url route's {page} variable
            int limit = 9; //number of images per page, let's not change this for now
            int offset = (int)page * 9 - limit; //get the offset for the current page

            //Giphy API Reqquest
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + key + "&q=" + q + "&limit=" + limit +
                "&offset=" + offset + "&rating=" + rating + "&lang=" + lang;

            //Get the JSON from Giphy
            //inspired by: https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
            WebRequest request = WebRequest.Create(url); //send the request
            WebResponse response = request.GetResponse(); //get the response
            Stream dataStream = response.GetResponseStream(); //start the data stream
            string reader = new StreamReader(dataStream).ReadToEnd(); //read in as a string

            //Parse the string into a JSON Object
            //inspired by: https://stackoverflow.com/questions/20437279/getting-json-data-from-a-response-stream-and-reading-it-as-a-string
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); //prepare the serializer to parse
            var data = serializer.DeserializeObject(reader); //parse the string into a JSON object with the serializer's Deserialize method

            //clean up
            dataStream.Close(); //close the stream
            response.Close(); //close the response
            return Json(data, JsonRequestBehavior.AllowGet); //return the JSON object, allow GET requests
        }
    }
}