using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject.Controllers
{
    public class HomeController : Controller
    {
        //Action Methods

        // GET ~/Home/Index
        // GET ~/Home/
        // GET ~/
        public ActionResult Index()
        {
            return View();
        }

        // GET ~/Home/Page1
        public ActionResult Page1()
        {
            return View();
        }
    }
}