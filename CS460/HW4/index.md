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
VIEW
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



##  Step 4: Create the second page <br /> 
##  Uses Form Data (POST) gathered with a FormCollection object



##  Step 5: Create the third page <br />
##  Uses Form Data (POST) gathered using model binding in controller action methods



##  DEMO:

### Home (Launch) Page:


### Page 1 - Query Strings:


### Page 2 - FormCollection Object:


### Page 3 - Model Binding:

