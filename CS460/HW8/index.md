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


## Step 4: Implement a CRUD fore Artists
1. Index/List Page:

2. Create page:

3. Details page:

4. Edit page:

5. Update page:

6. Delete page:

## Step 5: List items of a Genre on mainpage using AJAX


[back to portfolio](https://skoliver89.github.io)