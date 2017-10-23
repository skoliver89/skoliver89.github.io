---
title: Stephen Oliver
layout: default
---
## CS460 Homework 4 - Journal

This assignment will assist in learn ASP.NET MVC 5. The student will write a simple, multi-page
MVC application. This is the first MVC project, therefore databases are not in use (i.e. the project contains learn objectives for the V and C portion of the MVC framework). ViewBag/ViewData will be used to transfer data from controler to view. The studed will learn to use the Request object to utilize query strings and form data. Further, Razor will be slowly implement throughout the various pages to create dynamic page content. The student will implement previously learnt C# and further biuld on those skills. Also, the student must uderstand the operation of controller action methods. Finally, the student will learn the relationships between Models, Views, and Controllers.

Instructions for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4.html).

For a live demo of the web-app click: [here](http://myfirstmvcproject20171022055904.azurewebsites.net/)

## Step 1: Create an empty MVC 5 project with Visual Studio 2017

First, I had to create a new project. From here I selected Web -> ASP.NET Web Application. Don't forget to select the save location to the git repo. Also, this is where you name your application and solution. This will promt the New ASP.NET Project window pop-up. Here, select Empty, check only the MVC box, and click create project.

At this point the project is empty; it contains no javascripts or bootstrap code. Nor does it have a shared layout or CSS file. To generate this first create a HomeController and the View for the Index and build the project.

## Step 2: Create the Home (launch) page

The home (launch) page is the simplest of the pages for this project. All that is needed is an unordered list that lists the other pages in the project using Razor code.

This is how I implemented that list:<br />
ACTION METHOD
```cs
public ActionResult Index()
{
    return View();
}
```
VIEW -> Unordered List
```html
<ul class="list-group">
    <li class="list-group-item">@Html.ActionLink("Page 1", "Page1", "Home")</li>
    <li class="list-group-item">@Html.ActionLink("Page 2", "Page2", "Home")</li>
    <li class="list-group-item">@Html.ActionLink("Page 3", "Page3", "Home")</li>
</ul>
```
Note that I used some bootstrap and css to fancy it up.

The ActionLink HTML Helper params are: Link Text, ActionMethod, ControllerName in that order.

##  Step 3: Create the first page <br />
##  Uses Query Strings (GET)

For this Page we were instructed to create a form with at least 2 textfields and (using GET)
retrieve the intput data in the controller. Then do some computation with that data and return
the solution to the user in a "new page". I elected to create a temperature convertor that takes a value in either F, C, K, or N units and then converts the given value into the other
three units. The form uses one number input and 4 radio inputs. I elected to use radios instead of a text field for the unit type so that the user could not possibly provide an unsupported unit of measurement.

Here is a code snippet of my html form using the GET method:
```html
<div class="container">
    <form method="get" class="form-horizontal">
        <div class="form-group">
            <label for="temperature">Temperature</label>
            <input type="number" name="temperature" step="0.01" value="" class="form-control" />
        </div>
        <div class="form-group">
            <div class="radio-inline">
                <label for="F">F</label>
                <input type="radio" name="units" id="F" value="F" checked="checked" />
            </div>
            <!--ETC for the other radios-->
        </div>
        <div class="form-group">
            <button type="submit" class="btn btn-primary">Submit</button>
        </div>
    </form>
</div>
```
Note: I ommited 3 of the 4 radios to save space in this journal, see source for full code.

I collected the data in the collected the data entered with the query string proved by the
html form after the submit button is clicked. This is done inside of the Page2 Action Method.
```cs
public ActionResult Page1()
{
    string temperature = Request.QueryString["temperature"];
    string units = Request.QueryString["units"];

//...
}
```

I wanted to be able to add the proved value and units to the user inside the answer section
of the page so I added them to the ViewBag.
```cs
ViewBag.temperature = temperature;
ViewBag.units = units;
```
The ViewBag is used by specifying a key after a period and then storing a value inside of it
paired with that key on the right of an equals sign.

After collection the data I ran my conversion formulas on the provided value and placed
them into the ViewBag with unique "keys". For example, this is how I handle a value in F.
```csharp
public ActionResult Page1()
{
// ...
    if (temperature != null && temperature != "")
    {
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
                        
            //...
        }
    }

    return View();
}
```

For this page I decided to not even allow the answer section of the view to be
rendered if the user tries to supply a null or empty value. If the user enters
a value into the field other than a number the browser will simply generate a
notification to the error for the field.
Here is a code snippet describing the answer section of the Page1 view:
```html
@if (ViewBag.temperature != "" && ViewBag.temperature != null) //do nothing if empty/null value is found
{
    <div class="alert alert-success">
        <dl>
            <dt class="list-group-item-heading">Provided Temperature: </dt>
            <dd class="list-group-item">@ViewBag.temperature@ViewBag.units</dd>
            <dt class="list-group-item-heading">Converted to @ViewBag.aU:</dt>
            <dd class="list-group-item">@ViewBag.a@ViewBag.aU</dd>
            <!-- ... -->

        </dl>
    </div>
}
```
Note, I ommited 3 of the 4 converted values to save space.

##  Step 4: Create the second page <br /> 
##  Uses Form Data (POST) gathered with a FormCollection object

For this page our form had the same requirements as Page 1. This difference for this
page is that instead of GETing our form data with query strings we will be POSTing the
data from the form to the controller and recieving it as a FormCollection Object.
For this Page I created a POSTFIX/INFIX Calculator. To save space I will ommit the code for the POSTFIX portion of the calculator; it uses the same lagic as the one from HW3. The calculator is also setup to be able to round up to a given number of decimal places.

First I had to let the client (user) GET the initial page. The controller handles this part of the page load order.
```cs
 //GET ~/HOME/Page2
[HttpGet]
public ActionResult Page2()
{
    return View();
}
```
The View is loaded with just the form since it is in GET mode.
Here is what the form looks like:
```html
<div class="container">
    <form method="post" class="form-horizontal">
        <div class="form-group">
            <!--Text field for entering the equation-->
            <label for="equation">Equation</label>
            <input type="text" class="form-control" name="equation" placeholder="Input an equation"/>
            <!--Radio to select the type of calculator to use (PostFix)-->
            <div class="radio-inline">
                <label for="pf">Postfix</label>
                <input type="radio" value="postfix" name="type" id="pf" checked="checked" />
            </div>
            <!--Radio to select the type of calculator to use (InLine)-->
            <div class="radio-inline">
                <label for="in">Infix</label>
                <input type="radio" value="infix" name="type" id="in" />
            </div>
        </div>
        <div class="form-group">
            <!--Number field for selecting the number of decimal places in solution-->
            <label for="decimalPlaces">Number of Decimal Places (Solution)</label>
            <input type="number" class="form-control" name="decimalPlaces" min="0" max="15" value="0"/>
            <br />
            <button type="submit" class="btn btn-primary">Calculate</button>
        </div>
    </form>
</div>
```
The form uses the post method and takes a string from the user via a text field which will be the equation. Then a radio is selelected to indicate the equation format (POSTFIX or INFIX). Lastly, the user enters a number into the number input field to indicate how the calculator should round.

Next, we recieve the data into the controller via the FormCollection object and do math stuff with it.
```cs
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

    //...
}
```

I used a built that was new to me to compute the string of an infix expression.
```cs
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
```

Then the data is sent back to the view with the ViewBag like before;however, I changed to a more robust error handling method starting with this page. basically the Action method gets results from the private methods in a string array that holds 2+ values. The first value is always a status code indicating if an answer was found or an error was thrown and caught. The remaining indexes of the array are messages representing the answer(s) or error message.
Here is how I sent the array elements back to the view with ViewBag
```cs
ViewBag.status = output[0];
ViewBag.message = output[1];
ViewBag.type = type.ToUpperInvariant();
```
The type key is used to indicate in the solution section of the view which calculator was used.

Here is how the solution is presented back to the client if the page is in POST mode.
```html
@if (IsPost)
{
    if(ViewBag.status == "ok")
    {
        <div class="alert alert-success">
            <dl class="list-group">
                <dt class="list-group-item-heading">
                    @ViewBag.type Solution:
                </dt>
                <dd class="list-group-item">
                    @ViewBag.message
                </dd>
            </dl>
        </div>
    }
    if(ViewBag.status == "error") 
    {
        <div class="alert alert-danger">
            <dl class="list-group">
                <dt class="list-group-item-heading">
                    Error:
                </dt>
                <dd class="list-group-item">
                    @ViewBag.message
                </dd>
            </dl>
        </div>
    }
}
```

##  Step 5: Create the third page <br />
##  Uses Form Data (POST) gathered using model binding in controller action methods

For this page we took the GET/POST method even further with model binding in the controller.
That is, we recieved the values of the form data with parameters in the signature of the action method. A loan calculator was suggested for this page so I created one that calculates the EMI of an auto loan. The formula for EMI is: EMI = (P * r * (1 + r)^n)/((1 + r)^n - 1) where P = Loan Amount - Down Payment, r = Annual Interest Rate / 1200, and n = term (months).

The form has four number input fields, each of which has unique input limitation and requirements so that the formula does not return a NaN solution. There is nothing used to create this form that I did not use in previous forms so I will not be providing a code snippet; however, the source code is open to viewers on my github repository.

Here is how I gathered the data with the model binding in the controller.
```cs
//GET ~/Home/Page3
[HttpGet]
public ActionResult Page3()
{
    return View();
}

//POST ~/Home/Page3
[HttpPost]
public ActionResult Page3(double? amount, double? down, double? rate, int? term)
{
    //...
}
```


The private method inside the contol first had to convert the nullable types to the default non-nullable types I performed this inside a try/catch block so that if a parameter was null the error would be caught and handled in a clean way.
```cs
try
    {
        //calculate the variables needed for the formula
        //nullable types must be cast out now, no nulls allowed 
        //if a null value is found go to the catch.
        double p = (double)amount - (double)down;
        //Debug.WriteLine($"P = {p}");
        double r = (double)rate / 1200;
        //Debug.WriteLine($"r = {r}");
        double n = (double)term;
        //Debug.WriteLine($"n = {n}");

        //...
    }
    catch //...
```
I performed the calculations in this same try/catch block so that computation errors would similarly be cleanly handled. Like for page2 the solutions are inserted into a string array.
```cs
double emi = (p * r * Math.Pow((1 + r), n)) / (Math.Pow((1 + r), n) - 1);
output[1] = $"${emi.ToString("0.00")}";                 //EMI
output[2] = $"${(emi * n).ToString("0.00")}";           //Total amount in payments
output[3] = $"${((emi * n) - p).ToString("0.00")}";     //Total Interest payment
```

For this page I added a little more customization to the error handling.
```cs
 catch (InvalidOperationException) //A parameter was left empty by the user
{
    output[0] = "error"; //this will indicate to the view that we are kicking back an error message.
     output[1] = "All number fields must have a value; please check your data and re-enter the parameters.";
            }
catch (Exception e) //Wut?
{
    output[0] = "error";
    output[1] = $"Unexpected {e.GetType().Namespace} Exception: {e.Message}";
}
```
The last catch block is a custom handler that I created to keep unexpected exceptions from overwhelming the client with complex error printouts whlie still being informative.

The private method the returns the array containing the status code and message(s) back to the action method. The action method then deals out the array elements to the ViewBag and generates and returns the page's POST view object.

I presented the solution, or error, after the page is POSTed to the client in the same mannor that I did with page2 so I will be providing no further code snippets for that process on this page. This is a measure to save space and precious reader time.

##  Guided Animated DEMOs:
I appoligize in advance for any resolution loss.

### Home (Launch) Page:
![Homepage Demo](/Assets/HomeDemo.gif)

### Page 1 - Query Strings:
![Page 1 Demo](/Assets/Page1Demo.gif)
![Page 1 Demo](/Assets/Page1DemoText.jpg)
![Page 1 Demo](/Assets/Page1DemoQS.jpg)

### Page 2 - FormCollection Object:
![Page 2 Demo](/Assets/Page2Demo.gif)

### Page 3 - Model Binding:
![Page 3 Demo](/Assets/Page3Demo.gif)
