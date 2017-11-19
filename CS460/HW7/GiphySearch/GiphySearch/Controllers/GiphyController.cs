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

        public JsonResult Search(int? page = 2)
        {
            //Giphy API params
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            string q = Request.QueryString["q"];
            string rating = Request.QueryString["rating"];
            string lang = Request.QueryString["lang"];

            //Pagination Params - the page variable is from the url route's {page} variable
            int limit = 9; //number of images per page, let's not change this for now
            int offset = (int)page * 9 - limit; //get the offset for the current page

            //Giphy API Reqquest
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + key + "&q=" + q + "&limit=" + limit +
                "&offset=" + offset + "&rating=" + rating + "&lang=" + lang;

            //Get the JSON from Giphy
            //inspired by: https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            string reader = new StreamReader(dataStream).ReadToEnd();
            //inspired by: https://stackoverflow.com/questions/20437279/getting-json-data-from-a-response-stream-and-reading-it-as-a-string
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var data = serializer.DeserializeObject(reader);

            //clean up
            dataStream.Close(); //close the stream
            response.Close(); //close the response
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}