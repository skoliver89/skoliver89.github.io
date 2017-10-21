using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject.Controllers
{
    public class HomeController : Controller
    {
        //Action Methods//

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

        //GET ~/HOME/Page2
        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        //POST ~/HOME/Page2
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            string equation = Request.Form["equation"];
            string type = Request.Form["type"];
            int decimalPlaces = Int32.Parse(Request.Form["decimalPlaces"]);
            string[] output = { "error", "Calculator Type Not Found!"};

            //determine if expression is postfix or infix
            //this is controled with a pair of radios defaulted to postfix
            //thus, it is impossible to have any value other that "postfix" or "infix"
            if (type == "postfix") //evaluate as a postfix expression
            {
                output = postfixCalc(equation, decimalPlaces);
            }
            if (type == "infix") //evaluate as a infix expression
            {
                output = infixCalc(equation, decimalPlaces);
            }
            ViewBag.status = output[0];
            ViewBag.message = output[1];
            ViewBag.type = type.ToUpperInvariant();
            Debug.WriteLine($"{equation} : {decimalPlaces} : {type}"); //check the params in Debugger
            return View();
        }

        //GET ~/Home/Page3
        [HttpGet]
        public ActionResult Page3()
        {
            return View();
        }

        //POST ~/Home/Page3
        [HttpPost]
        public ActionResult Page3(double amount, double down, double rate, int term)
        {

            Debug.WriteLine($"{amount} : {down} : {rate} : {term}");
            return View();
        }

        //Because we aren't using Models yet, data processing goes here//

        //POSTFIX Methods
        //calcuate and return the solution of a postfix formatted expression
        //rounded to r places
        private string[] postfixCalc(string equation, int r)
        {
            Regex rgx = new Regex(@"\s+");
            string[] elements = rgx.Split(equation);
            Stack<double> stack = new Stack<double>();
            string[] output = { "ok", $"[{equation}] = " };

            foreach(string element in elements)
            {
                if(IsOperator(element))
                {
                    try
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        stack.Push(DoMath(element, a, b));
                    }
                    catch(Exception e)
                    {
                        output[0] = "error";
                        if (e.Message == "Stack empty.")
                        {
                            output[1] = "Not enough numbers to evaluate the expression.";
                        }
                        else
                        {
                            output[1] = e.Message;
                        }
                        return output;
                    }
                }
                else if(IsNumber(element))
                {
                    stack.Push(Double.Parse(element)); //push the number to the stack
                }
                else
                {
                    output[0] = "error";
                    output[1] = $"{element} is not a valid number or operator.";
                    return output;
                }
            }

            output[1] += $" {Math.Round(stack.Pop(), r).ToString()}";
            if(stack.Count != 0)
            {
                output[0] = "error";
                output[1] = "Not enough operands to evaluate the expression";
            }
            return output;
        }

        //INFIX Methods
        //calculate and return the solution of a infix formatted expression
        //rounded to r places
        //inspired by: https://stackoverflow.com/questions/21950093/string-calculator
        private string[] infixCalc(string equation, int r)
        {
            string[] output = { "ok", $"{equation} = " };
            try
            {
                //use built in Compute (via System.Data -> DataTable) to evaluate the string equation 
                //doing this instead of reinventing the wheel to save time.
                //convert the Compute object to a double so that we can round before returning
                double eval = Convert.ToDouble(new DataTable().Compute(equation, null));
                output[1] += Math.Round(eval, r).ToString();
            }
            catch(Exception e) //catch errors from the compute
            {
                output[0] = "error";
                output[1] = e.Message;
            }
            return output;
        }

        //MISC private methods
        //check it string is a valid number (-inf to +inf)
        private bool IsNumber(string s)
        {
            Regex rgx = new Regex(@"^[-|+]?(?:\d*\.)?\d+$");
            if (rgx.IsMatch(s))
            {
                return true; //is a number
            }
            return false; //is not a number
        }
        //check if string is a valid operator
        private bool IsOperator(string s)
        {
            Regex rgx = new Regex(@"^[+*/-]$");
            if (rgx.IsMatch(s)) //test if the element is a math operator (* + - /)
            {
                return true; //is an operator
            }
            return false; //is not and operator
        }
        //math
        //determine operator and do corresponding calculation
        private double DoMath(string op, double a, double b)
        {
            double answer = 0;
            switch (op)
            {
                case "+":
                    answer = a + b;
                    break;
                case "-":
                    answer = a - b;
                    break;
                case "*":
                    answer = a * b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    answer = a / b;
                    break;
            }
            return answer;
        }

        //Calculate The Loan EMI (Equated Monthly Installment)
        //Formula found at: https://www.easycalculation.com/mortgage/auto-loan-emi.php
        //EMI = (P * r * (1 + r)^n)/((1 + r)^n - 1)
        //P = Loan Amount - Down Payment 
        //r = Annual Interest Rate / 1200
        //term (months)
        private decimal GetEMI(double amount, double down, double rate, int term)
        {


            return 0.0m;
        }
    }
}