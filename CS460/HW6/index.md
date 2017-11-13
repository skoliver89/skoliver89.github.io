---
title: Stephen Oliver
layout: default
---
## CS460 Homework 6 - Journal

## Primary Objectives:

1. Be able to write a MVC web application that uses portions of a large, complex pre-existing database
2. Be able to derive C# models from an existing database using Entity Framework and “Code First with an Existing Database” workflow
3. Be able to write LINQ queries using fluent syntax
4. Learn to use C# language features: partial classes
5. Use more Razor language features to build feature-laden views

## Overall Requirements:

* You must use “Code First with an Existing Database” workflow
* Don't add and commit your database file (ignore it please; it's 205 MB)
* If you need to add something to a model class, do it in a new file (still in the model folder) and use a partial class
* Make this a single website, with a landing page and links as appropriate. * * * Remove unnecessary boilerplate and add in something to make it look like a prototype of a real system
* You should prefer strongly-typed views over untyped viewbag-only views
* Use only fluent LINQ syntax (dot notation) and not query syntax (the sql-like version)

## Demonstration Video 
I Could not get the project to publish correctly in the time I allotted myself for this project. Thus, the following video provides a guided tour/demonstration of the finished project. Note, This app was made in a matter of days, expect protype level features and visual quality.<br />
<a href="https://www.youtube.com/watch?v=P_OyhV2Y49Q" target="_blank"><img src="Journal_VideoImage.jpg" 
alt="Image Broken" width="240" height="180" border="5" /></a>

## Step 1: Recover the existing database, Adventure Works 2014
First, I went and got the AdventureWorks2014.bak file from the link indicated by the HW directions. The next step was to launch Microsoft SQL Server Management Studio 2017 and connect to my local MSSQL DB. There, I entered the name of the local server and left the authentication as the default setting handled by my Windows sign-in. Once the data was connected to the management studio I rick-clicked on the databases folder in the server and selected restore database. Next I had to selct the .bak file, it is used as a "disk" so I had to select the appropriate input field, browse for the file and hit run. The AdventureWorks2014 DB is now restored from the .bak file to my local SQL server for use by my application.

## Step 2: Utilize Entity Framework to auto-generate data models, database context, and connection string


## Step 3: Feature 1: Allow customers to browse products sold buy Adventure Works


## Step 4: Feature 2: Allow customers to create product reviews


## BONUS STEPS


## Bonus Step 1: Add product pictures from the database


## Bonus Step 2: Make the launch page do something cool
