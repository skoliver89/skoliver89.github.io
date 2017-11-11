using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class CatalogController : Controller
    {
        //interface to the DB
        AdventureWorks2014Context db = new AdventureWorks2014Context();
        // GET: Catalog
        public ActionResult Index()
        {
            //Get a list of Catagories to Return to the View
            return View(db.ProductCategories);
        }
    }
}