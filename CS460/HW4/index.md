---
title: Stephen Oliver
layout: default
---
## CS460 Homework 4 - Journal

This assignment will assist in learn ASP.NET MVC 5. The student will write a simple, multi-page
MVC application. This is the first MVC project, therefore databases are not in use (i.e. the project contains learn objectives for the V and C portion of the MVC framework). ViewBag/ViewData will be used to transfer data from controler to view. The studed will learn to use the Request object to utilize query strings and form data. Further, Razor will be slowly implement throughout the various pages to create dynamic page content. The student will implement previously learnt C# and further biuld on those skills. Also, the student must uderstand the operation of controller action methods. Finally, the student will learn the relationships between Models, Views, and Controllers.

Instructions for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4.html).

The collection of web-apps created for this assignment are not being hosted. The end of
this journal entry contains visual demonstrations. The source code can be found in the
GitHub repository linked to the button above.

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



##  Step 5: Create the third page <br />
##  Uses Form Data (POST) gathered using model binding in controller action methods



##  DEMO:

### Home (Launch) Page:


### Page 1 - Query Strings:


### Page 2 - FormCollection Object:


### Page 3 - Model Binding:

