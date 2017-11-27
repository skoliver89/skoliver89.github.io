---
title: Stephen Oliver
layout: default
---
## CS460 Homework 8 - Journal

## Primary Objectives:

1. Be able to write a MVC web application that uses a multi-table, relational database instance that you created
2. Be able to create models with foreign keys and navigation properties
3. Be able to implement CRUD functionality with non-trivial models
4. Learn to write more complex T-SQL scripts to create more complex database tables
5. Practice more LINQ
6. Implement custom attribute checking

## Overall Requirements:

* You must use a “Code First with an Existing Database” workflow
* Use a script to create your tables, populate them with sample data and another to delete them; the script(s) need to be added and committed to your git repository
* All pages must use strongly typed views
* Use only fluent (dot notation) LINQ syntax

Link to official HW requirements: [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8.html)

## Demonstrations
Guided video Demo:
<!-- youtube embed goes here -->
<br />
NOTE: The live version of this project will be available in HW9.

## ER Diagram
![ER Diagram](ERD.png)

## Step 1: UP/Down Script
1. UP Script:
The up.sql for this project was slightly more complex than the previous scripts that I wrote; the addition of the foreign key and forcing uniqueness on a field played a large part in this added complexity.

```sql
--Create the tables
CREATE TABLE dbo.Artists
(
	Name		VARCHAR(50)		NOT NULL,
	BirthDate	DATE			NOT NULL,
	BirthCity	VARCHAR(100)	NOT NULL

	CONSTRAINT [UC_dbo.Artists] UNIQUE (Name),
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY (Name)
);

CREATE TABLE dbo.ArtWorks
(
	Title	VARCHAR(100)	NOT NULL,
	Artist	VARCHAR(50)		NULL
	
	CONSTRAINT [UC_dbo.ArtWorks] UNIQUE (Title),
	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY (Title),
	CONSTRAINT [FK_db0.ArtWorks] FOREIGN KEY (Artist)
		REFERENCES dbo.Artists(Name)
			ON UPDATE NO ACTION
			ON DELETE NO ACTION
);

CREATE TABLE dbo.Genres
(
	Name	VARCHAR(50)	NOT NULL

	CONSTRAINT [UC_dbo.Genres] UNIQUE (Name),
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY (Name)
);

CREATE TABLE dbo.Classifications
(
	ArtWork	VARCHAR(100)	NOT NULL,
	Genre	VARCHAR(50)		NOT NULL

	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY (Artwork, Genre),
	CONSTRAINT [FK1_dbo.Classifications] FOREIGN KEY (Artwork)
		REFERENCES dbo.Artworks(Title)
			ON UPDATE NO ACTION
			ON DELETE CASCADE,
	CONSTRAINT [FK2_dbo.Classifications] FOREIGN KEY (Genre)
		REFERENCES dbo.Genres(Name)
			ON UPDATE NO ACTION
			ON DELETE CASCADE
);
```
I had to insert values in the proper order so that foreign keys existed in the required tables prior to an insert.

```sql
INSERT INTO dbo.Artists (Name, BirthDate, BirthCity) VALUES
-- ...
INSERT INTO dbo.ArtWorks (Title, Artist) VALUES
-- ...
INSERT INTO dbo.Genres(Name) VALUES
-- ...
INSERT INTO dbo.Classifications(ArtWork, Genre) VALUES
-- ..
GO
```
2. DOWN Script: 
For this project's down.sql I had to drop the tables is a specific order since some tables have forgein keys from other tables. The following ordier was required.

```sql
DROP TABLE IF EXISTS dbo.Classifications;
DROP TABLE IF EXISTS dbo.ArtWorks;
DROP TABLE IF EXISTS dbo.Genres;
DROP TABLE IF EXISTS dbo.Artists;
```

## Step 2: Artists/ArtWorks/Classifications Menu
There was nothing new done here that I have not previously done in other assignments. I simply created a link in the Navbar list for each of the menu requirements. I then created coresponding controller action methods and views to display the required information.

NavBar in the shared layout:
```html
<div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Art Vault", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Artists", "Artists","Home")</li>
                    <li>@Html.ActionLink("Art Works", "ArtWorks", "Home")</li>
                    <li>@Html.ActionLink("Classifications", "Classifications", "Home")</li>
                </ul>
            </div>
        </div>
    </div>
```

Artists in the HomeController:
```cs
//GET ~/Home/Artists
public ActionResult Artists()
{
    List<Artist> artists = db.Artists.ToList();
    return View(artists);
}
```

The Artists View
```cs
@model IEnumerable<ArtVault.Models.Artist>

@{
    ViewBag.Title = "Artists";
}

<h2>Artists</h2>

<p>
    @Html.ActionLink("Create New", "CreateArtist", null, new { @class = "btn btn-success" })
</p>
<table class="table table-hover table-responsive">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.BirthDate)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.BirthCity)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.BirthDate)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.BirthCity)
        </td>

        <td>
            <div class="btn-group">
                @Html.ActionLink("Edit", "EditArtist", new { id = item.Name }, new { @class = "btn btn-primary" })
                @Html.ActionLink("Details", "ArtistDetails", new { id = item.Name }, new { @class = "btn btn-default" })
                @Html.ActionLink("Delete", "DeleteArtist", new { id = item.Name }, new { @class = "btn btn-danger" })
            </div>
        </td>
    </tr>
}

</table>
```

NOTE: I chose to include the Artists code snippets to keep this journal readable and because I will later refer to this View in another step.

## Step 3: Add attribute checking
I decided to do my input checks with model attributes. I had to create a custom range attribute for my check to be sure that users do not enter a future date for BirthDate. Also, I used a metadata partial class to add attributes to my model properties since I used Entity Framework to generate the models and context class.

Custom Attribute (NoFutureDates.cs):
```cs
using System;
using System.ComponentModel.DataAnnotations;

namespace ArtVault.Models
{
    //Inspired by: https://stackoverflow.com/questions/17321948/is-there-a-rangeattribute-for-datetime

    /// <summary>
    ///Custom Attribute to limit a DateTime/Date Field
    ///Between Now() and the earliest possible year
    /// </summary>
    public class NoFutureDates : RangeAttribute
    {
        public NoFutureDates() : base(typeof(DateTime),
            DateTime.MinValue.ToShortDateString(),
            DateTime.Now.ToShortDateString())
        { }
    }
}
```

Check that users do not input a string longer than 50 for Artist Name. This was handled beautifully by EF.
```cs
[Key]
[StringLength(50)]
public string Name { get; set; }
```

MetaData file (ArtistMetadata.cs):
```cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtVault.Models
{
    public partial class ArtistMetadata
    {
        [DataType(DataType.Date)]
        //Fix for editfor population: https://stackoverflow.com/questions/33247295/show-only-the-date-in-html-editorfor-helper
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [NoFutureDates(ErrorMessage = ("Future dates are not allowed."))]
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"(([A-z]+[' -]?[A-z]*)[ ]?([A-z]+[' -]?[A-z]*)?, )+([A-z]+)|(Unknown)",
            ErrorMessage ="Expected format :" +
            " 'City, Country' or 'City, State, CountryCode' or 'Unknown")]
        public string BirthCity { get; set; }
    }

    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist { }

}
```

## Step 4: Implement a CRUD fore Artists
* Index/List Page: <br />
This page is the Artists Page from the menu in step 2.
<br />
* Create page:<br />
I added a create button to the top of the Artists page which directs the user to the CreateArtist action methods and view.

Razor to create the 'Create New' Button on the Artists Page:
```html
@Html.ActionLink("Create New", "CreateArtist", null, new { @class = "btn btn-success" })
```

The Create controller action methods:
```cs
 //GET ~/Home/CreateArtist
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        //POST ~/Home/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
           if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }
```
NOTE: Similar controllers are used in the Hw5 project as well.

The view for this page is basically just the scaffolded Create View using the Artists model; however, I had to add some fields since the scaffold felt it unnecessary to include them. I also changed the defaul links to a button group.

Create Button group:
```cs
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10 btn-group">
                <input type="submit" value="Create" class="btn btn-primary" />
                @Html.ActionLink("Cancel", "Artists", null, new { @class = "btn btn-danger" })
            </div>
        </div>
``` 
<br />
* Details page:<br />
For the Details page I utilized the id parameter in the default route to specify the artist's name (i.e. the PK for the Artists table). The action method is a standard(ish) GET method and the View is the scaffolded List View that I prettied up with some bootstrap and replaced the links with razor buttons.

Controller Action Method:
```cs
//GET ~/Home/ArtistDetails/{Artist Name}
public ActionResult ArtistDetails(string id)
{
    //Debug.WriteLine("ArtistName = " + id);
    Artist artist = db.Artists.Find(id);
    //Debug.WriteLine("artist.Name = " + artist.Name);
    return View(artist);
}
```

View:
```cs

@model ArtVault.Models.Artist

@{
    ViewBag.Title = Model.Name;
}

<h2>@Model.Name</h2>

<ul class="list-group">
    <li class="list-group-item">
        <h4 class="list-group-item-heading">@Html.DisplayNameFor(model => model.BirthDate)</h4>
        @Html.DisplayFor(model => model.BirthDate)
    </li>
    <li class="list-group-item">
        <h4 class="list-group-item-heading">@Html.DisplayNameFor(model => model.BirthCity)</h4>
        @Html.DisplayFor(model => model.BirthCity)
    </li>
    <li class="list-group-item">
        <h4 class="list-group-item-heading">Works</h4>
        @foreach (var work in Model.ArtWorks)
        {
            <p>@work.Title</p>
        }
        @if(Model.ArtWorks.Count() < 1){ <p>N/A</p>}
    </li>
</ul>
<div class="btn-group">
    @Html.ActionLink("Edit", "EditArtist", new { id = Model.Name }, new { @class = "btn btn-primary" })
    @Html.ActionLink("Back", "Artists", null, new { @class="btn btn-default"})
    @Html.ActionLink("Delete", "DeleteArtist", new { id = Model.Name }, new { @class = "btn btn-danger" })
</div>
```
<br />
* Edit page:<br />
The edit page uses some basic action methods I found in the Documentation and repurposed for my uses. Also, to save time I again used the scaffolded edit view with some minor changes similar to the previous views. I will ommit the view for this page since the changes are either obvious or stated similarly elsewhere.

Controller action methods
```cs
/GET ~/Home/EditArtist/{artist name}
        [HttpGet]
        public ActionResult EditArtist(string id)
        {
            Artist artist = db.Artists.Find(id);
            return View(artist);
        }

        //POST ~/Home/EditArtist/{artist name}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
            if(ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }
```

Initially, there was a bug that prevented the BirthDate field from populating. I had to add an attribute to the BirthDate property in the artist model to correct the formatting of the data retrieved from the database so that it would display.
```cs
 //Fix for editfor population: https://stackoverflow.com/questions/33247295/show-only-the-date-in-html-editorfor-helper
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
```
As seen in Step 3: Add attrigute checking.
<br />
* Delete page:<br />
I agian found the action methods that I needed for this page in the documentation and repurposed it for my uses. The view, however, is completely hand written. I decided to create a page-header that indicated that the user was trying to delete an artist and then list the artist's details followed by a button group to cancel or delete. This page is a confirmation page so that the user cannot accidentally delete an artist.

Controller action methods:
```cs
 //GET ~/Home/DeleteArtist/{artist name}
[HttpGet]
public ActionResult DeleteArtist(string id)
{
    Artist artist = db.Artists.Find(id);
    return View(artist);
}

//POST ~/Home/DeleteArtist/{artist name}
[HttpPost, ActionName("DeleteArtist")]
public ActionResult DeleteArtistConfirmed(string id)
{
    Artist artist = db.Artists.Find(id);
    db.Artists.Remove(artist);
    db.SaveChanges();
    return RedirectToAction("Artists");
}
```
Like for the Details and Edit pages, I used the default route's id parameter to indication the artist that the user wants to delete.
<br />
NOTE: The majority of these pages use the scaffolded views from VS2017 but with improvements handwritten by myself to save time.<br />

NOTE 2: I elected to not do custom redirects if the user foolishly tries to route to Details, edit, or delete pages to save on time. If the user uses the UI provided no errors should occur.<br />

## Step 5: List items of a Genre on mainpage using AJAX
First I added a spot at the bottom of the shared layout to load page scripts.
```html
    <script src="~/Scripts/jquery-3.2.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    @RenderSection("PageScripts", false)
```

Next, I added a link to the script file in my Index.cshtml file for the Home Controller Index View.
```html
@section PageScripts
{
    <script type="text/javascript" src="~/Scripts/home.js"></script>
}
```

I added some buttons to the Home/Index page, generated with a Razor foreach loop, with a trigger to my first JS function.
```html
<div class="btn-group">
    @foreach(var genre in Model)
    {
        <input class="btn btn-default" type="button"value=@genre.Name onclick="genreClicked('@genre.Name')" />
    }
</div>
<br />
```
I used a funtion trigger so that I could pass the genre name to the funciton in my home.js file.

Once a button is clicked the genreClicked function is triggered and uses AJAX for request a JSON object from an the GenreDetails action method. If the AJAX call to my action method return successful with would trigger the displayResults funtion. Else, it will call a function that just prints to the browser log that an error occured; this function exists for light debugging and is of little to no use to the user.
```js
function genreClicked(genre)
{
    //console.log(genre);
    var source = "/Home/GenreDetails/" + genre;
    //console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: errorOnAjax
    });
}
```

I hid a results section in my Index View.
```html
<div id="results" style="display: none">
    <table class="table table-hover table-responsive">
        <thead>
            <tr>
                <th>Art Work</th>
                <th>Artist</th>
            </tr>
        </thead>
        <tbody id="resultsBody">
            @*JS generated stuff from AJAX/JSON goes here*@
        </tbody>
    </table>
</div>
<br />
```

If the displayResults function is called it will populate the table with the data from the JSON object using a jQuery each loop and then unhide the results section in the Index View.
```js
function displayResults(data)
{
    //console.log("AJAX Success!");
    //console.log(data);

    //iterate through the json obj with jQuery
    //inspired by: https://stackoverflow.com/questions/1078118/how-do-i-iterate-over-a-json-structure
    var item = document.getElementById("resultsBody");
    jQuery.each(data, function (i, val) {
        //console.log(val["Title"]);
        //console.log(val["Artist"]);
        if (i == 0) {
            item.innerHTML = '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] +'</td></tr>';
        }
        else {
            item.innerHTML += '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] + '</td></tr>';
        }
    });
    $("#results").css("display", "block");
```

[back to portfolio](https://skoliver89.github.io)