using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    //interface to the DB/models   
    public class HomeController : Controller
    {
        AdventureWorks2014Context db = new AdventureWorks2014Context();
        // GET: Home
        public ActionResult Index()
        {
            //Get the five most recent reviews to display on launch page
            var reviews = db.ProductReviews.OrderByDescending(o => o.ReviewDate).Take(5);

            return View(reviews);
        }
    }
}