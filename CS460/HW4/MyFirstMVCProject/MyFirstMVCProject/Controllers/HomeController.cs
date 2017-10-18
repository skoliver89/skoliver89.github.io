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
                //Convert to F, C, and/or K depending on what unit is supplied
                //Formulas found here: https://en.wikipedia.org/wiki/Conversion_of_units_of_temperature
                switch (units)
                {
                    case "F":
                        ViewBag.a = ((t - 32.00) * (5.00 / 9.00)).ToString();   //F to C
                        ViewBag.b = ((t + 459.67) * (5.00 / 9.00)).ToString();  //F to K
                        ViewBag.c = ((t - 32.00) * (11.00 / 60.00)).ToString(); //F to N
                        ViewBag.aU = "C"; //send the unit label for Celsius
                        ViewBag.bU = "K"; //send the unit label for Kelvin
                        ViewBag.cU = "N"; //send the unit label for Newtons
                        break;
                    case "C":
                        ViewBag.a = (t * (5.00 / 9.00) + 32.00).ToString();  //C to F
                        ViewBag.b = (t + 273.15).ToString();                 //C to K
                        ViewBag.c = (t * (33.00/100.00)).ToString();         //C to N
                        ViewBag.aU = "F"; //send the unit label for Fahrenheit
                        ViewBag.bU = "K"; //send the unit label for Kelvin
                        ViewBag.cU = "N"; //send the unit label for Newtons
                        break;
                    case "K":
                        ViewBag.a = (t * (5.00 / 9.00) - 459.67).ToString();      //K to F
                        ViewBag.b = (t - 273.15).ToString();                      //K to C
                        ViewBag.c = ((t - 273.15) * (33.00 / 100.00)).ToString(); //K to N
                        ViewBag.aU = "F"; //send the unit label for Fahrenheit
                        ViewBag.bU = "C"; //send the unit label for Celsius
                        ViewBag.cU = "N"; //send the unit label for Newtons
                        break;
                    case "N":
                        ViewBag.a = (t * (60.00 / 11.00) + 32.00).ToString();   //N to F
                        ViewBag.b = (t * (100.00 / 33.00)).ToString();          //N to C
                        ViewBag.c = (t * (100.00 / 33.00) + 273.15).ToString(); //N to K
                        ViewBag.aU = "F"; //send the unit label for Fahrenheit
                        ViewBag.bU = "C"; //send the unit label for Celsius
                        ViewBag.cU = "K"; //send the unit label for Kelvin
                        break;
                }
            }


            return View();
        }
    }
}