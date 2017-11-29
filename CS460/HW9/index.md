---
title: Stephen Oliver
layout: default
---
## CS460 Homework 8 - Journal

## Primary Objectives:

1. Be able to write a complex MVC web application and deploy to the cloud
2. Learn how to provision and deploy a database to the cloud

## Overall Requirements:

* Use Azure for both the web application and the database
* Must build the database from script files that are maintained in your project under Git
* Your database password cannot appear in your Git repository

Link to official HW requirements: [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW9.html)

## Link To Live Site
[Art Vault (HW8/9) Azure Link]()

## Step 1 - Create Azure SQL Server Database
1. Log into Azure Portal and click on "SQL databases."
2. Click "Add" in the top right 
3. Fill out the details and click create, this will take some time.

![SQL Database Create](dbCreate.png)

## Step 2 - Create Tables From up.sql In Project
1. Open MSSQL Management Studio 2017
2. Connect to the azure database server. Found at the top of the DB server overview on the Azure Portal under "Server name."
3. Open up.sql from the project App_Data folder. File -> Open File
4. Execute up.sql on the Azure SQL Server DB

![Server Name](serverName.png)
![Connect MSSMS To DB](connectDB.png)
![Open UP Scrpit](openUpScript.png)
![Run UP Script](executeUpScript.png)
![Tables Created](createdTables.png)
Azure DB ERD:
![ERD](ERD.png)


## Step 3 - Create Azure App Resources/Service
1. 

## Step 4 - Publish App

