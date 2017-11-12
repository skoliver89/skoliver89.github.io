using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class MenuController : Controller
    {
        AdventureWorks2014Context db = new AdventureWorks2014Context();
        // Provide data to generate dropdowns for the navbar (menu)
        [ChildActionOnly]
        public ActionResult Index()
        {
            var categories = db.ProductCategories;
            return View("~/Views/Shared/_Layout.cshtml", categories);
        }
    }
}