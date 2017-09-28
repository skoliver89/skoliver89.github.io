---
title: Stephen Oliver
layout: default
---
## Homework 1 - Journal

Homework 1 contains tasks to familiarize one's self with HTML, CSS, and Git. Also, we were instructed
to use the Bootstrap framework to improve the style of our pages.

The instructions for this homework are located [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html). Basically, we are to create a set of linked HTML5 pages using bootstrap and our own CSS stylesheet.

### Step 1: Download Git, Learn a Basic Workflow, Create Accounts on GitHub and Bitbucket

First, I downloaded Git Bash for windows. In order to push to and pull from a remote repository I will need to create one; I chose to utilize GitHub since I already had an account and we will be using GitHub's pages for journalling and porfolios. After logging into my GitHub account, I created a repo for my portfolio called "skoliver89.github.io". The naming was very important if I wished to use pages (i.e. <somename>.github.io). While creating the repo I created a README file using the web interface.

At this stage it was time to create the local repo; I chose to call my local repo 
"SeniorProject". I then initialized the local repo with git and setup my connection parameters for the remote repo. I had to do a pull off of my remote repo since the remote contained the README and the local version did not. My local and remote repositories are now setup to get some work done!
```bash
cd /C/Users/Oliver/Documents
mkdir SeniorProject
cd SeniorProject
git remote add origin https://github.com/skoliver89/skoliver89.github.io
git pull origin master
```

### Step 2: HTML, CSS, and Bootstrap

The Website I created can be viewed [here](https://skoliver89.github.io/CS460/HW1/hw1.html).

First, I created a README file that spells out the topic and page setup of my website. 
Also, I was sure to include the resources I used to create the pages.
At this point I created a general html template using bootstrap and my css stylesheet.

```html
<html lang="en">
  <head>
    <title>Squeaks' Overwatch Fansite</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" 
    integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" 
    crossorigin="anonymous">
    <!-- My CSS -->
    <link rel="stylesheet" href="style.css">
  </head>
  <body>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" 
    integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" 
    crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" 
    integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" 
    crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" 
    integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" 
    crossorigin="anonymous"></script>
  </body>
</html>
```

### Step 3: Cloning


### Step 4: GitHub Pages and Journal Entry

This step was simple. All I did was go into the remote repo's settings and make sure that github pages was active and selected a theme. As for the journal entries, I added index.md files to the main repo folder and the HW1 folder. The main index file contains an intro the the portfolio and links to the assignments. Within the HW1 index file I created the content you are reading now! I then, as before, added, commited, and pushed the index files and github pages took care of the rest.