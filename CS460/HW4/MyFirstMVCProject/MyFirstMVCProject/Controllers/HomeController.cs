using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Get parameter values from the client via query strings
            string temperature = Request.QueryString["temperature"];
            string units = Request.QueryString["units"];
            // Build a new page with the param values
            //return what the user put into the form to the newpage
            ViewBag.temperature = temperature;
            ViewBag.units = units;

            if (temperature != null && temperature != "")
            {
                //Convert the given temp to a double
                double t = Double.Parse(temperature);
                //constant for F to C and F to K
                double x = 5.00 / 9.00;
                //constant for F to N
                double y = 11.00 / 60.00;
                //Convert to F, C, and/or K depending on what unit is supplied
                switch(units)
                {
                    case "F":
                        ViewBag.a = ((t - 32.00) * x).ToString();
                        ViewBag.b = ((t + 459.67) * x).ToString();
                        ViewBag.c = ((t - 32.00) * y).ToString();
                        ViewBag.aU = "C"; //send the unit label for Celsius
                        ViewBag.bU = "K"; //send the unit label for Kelvin
                        ViewBag.cU = "N"; //send the unit label for Newtons
                        break;
                    case "C":

                        break;
                    case "K":

                        break;
                }
            }


            return View();
        }
    }
}