---
title: Stephen Oliver
layout: default
---
## CS460 Homework 1 - Journal

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
At this point I created a general html template using bootstrap and my css stylesheet. This basic template was found on the bootstrap site and I modified it for my project.
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
Next, I added in the Navigation Bar using Unordered Lists within a bootstrap navbar class. Also, this navbar contains a dropdown menu and the ability to collapse if the screen/window is small. I also found the code for this navbar on the bootstrap site and modified it to fit with my project better.
```html
<!-- Nav Bar -->
    <nav class="navbar fixed-top navbar-fixed navbar-expand-lg navbar-dark" style="background-color: #0d0d0d;">
      <a class="navbar-brand" href="index.html">Overwatch</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" 
      aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div class="navbar-nav">
          <ul class="navbar-nav">
            <li class="nav-item active">
              <a class="nav-link" href="index.html">Home<span class="sr-only">(current)
                </span></a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">My Stats</a>
            </li>
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="http://example.com" 
              id="navbarDropdownMenuLink" data-toggle="dropdown" 
              aria-haspopup="true" aria-expanded="false">
                My Favorite Heroes
              </a>
              <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                <a class="dropdown-item" href="#">D.Va</a>
                <a class="dropdown-item" href="#">Lucio</a>
                <a class="dropdown-item" href="#">Reaper</a>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </nav>
```
I then setup the container under the navbar that would hold the content for the homepage. I decided to make the homepage a simplier, one column, style.
```html
<!-- Page Content -->
    <div class="container-fluid" id="main-container">
      <div class="row" id="header-row">
          <h1>Page Title</h1>
      </div>   
      <div class="row" id="content-home">
          <p>Content stuff goes here</p>
      </div>
      <div class="row" id="content-home">
          <p>Content stuff goes here</p>
      </div>
    </div>
```
This is what a 2+ column layout looks like:
```html
<!-- Page Content -->
<div class="container-fluid" id="main-container">
    <div class="row">
        <div class="col">
        <!-- Column 1 of Row 1 -->
        </div>
        <div class ="col">
        <!-- Column 2 of Row 1 -->
        </div>
        <div class="col">
        <!-- Column 3 of Row 1 -->
        </div>
    </div>
    <div class="row">
    <!-- This Row Has Only one column!! -->
    </div>
</div>
```
Now that we have a basic template setup it is time to start adding some content to the main/home page. Lets title it: "About The Player: Squeaks". It might also be valuable to add and image and some lists to display some interesting info about me, the player. We can also start working on our css file.

For the css file I change some padding, min-height, max-width, and background colors and images.
```css
html, body {
    height: auto;
    }
body {
    padding-top: 60px;
    background-image: url("assets/HW1-SiteBG.jpg");
    background-color: #0D0D0D;
}
#main-container {
    max-width: 90%;
    min-height: auto;
    background-image: url("assets/HW1-containerBG.jpg");
    background-color: #f2f2f2;
}
#header-row {
    padding-bottom: 8px;
}
#img-row {
    padding-bottom: 10px;
}
```
I decided to keep the text as default value for now to keep it simple.

Next, lets add our next page called "My Stats" and populate it with some generic gameplay stats for me.

For the next two pages we will add in some pictures, stats, and general notes on my top two favorite characters. I decided to removed the third favorite, Reaper, to simplify the assinment a little.

Here we can see an example of some page content from the homepage. I have used a bootstrap
image and a description list in the for of a short mock interview.
```html
<!-- Page Content -->
    <div class="container-fluid" id="main-container">
      <div class="row" id="header-row">
          <h1>Home - About Me</h1>
      </div>   
      <div class="row" id="image-home">
        <img src="assets\Me.jpg" class="img-fluid" alt="image broken!"> 
      </div>
      <div class="row" id="content-home">
        <dl>
          <dt>How old are you?</dt>
          <dd>Currently, I am 28 years old.</dd>
          <dt>When did you start gaming?</dt>
          <dd>I started gaming when I was about 6 years old playing a coloring
          book game on my parents' PC. Things started to get serious once I started
          playing Mario games on the NES and SNES.
          </dd>
          <dt>How did you get into competive games, like Overwatch?</dt>
          <dd>I first started playing competive games when my Dad let me play
          Wolfenstein ET, but I didn't play much and only really got into the
          game type once Overwatch released to beta.
          </dd>
          <dt>What is your favorite thing about Overwatch?</dt>
          <dd>I have to say that my all time favorite thing about the game [Overwatch]
          is that it is a ton of fun to play with friends and try out new team compositions.
          </dd>
        </dl>
      </div>
    </div>
```
Here is an ordered list example:
```html
<!-- Page Content -->
<ol>
    <li>Sonic Amplifier</li>
    <li>Crossfade</li>
    <li>Amp It Up</li>
    <li>Sound Barrier</li>
</ol>
```
And an unordered list:
```html
<!-- Page Content -->
<ul>
    <li>Image courtesy of: <a href="https://playoverwatch.com">playoverwatch.com</a></li>
    <li>Abilities and Facts are from: <a href="https://playoverwatch.com">playoverwatch.com</a></li>
    <li>Player-Character Stats are from: <a href="https://overprogress.com">overprogress.com</a></li>
    <li>Don't forget to wall-ride!!</li>
</ul>
```

Finally, now that the other pages are created we need to replace the # marks in the hrefs to be links to the apropriate pages.
The previous navbar code:
```html
<li class="nav-item">
    <a class="nav-link" href="#">My Stats</a>
</li>
<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="http://example.com" 
    id="navbarDropdownMenuLink" data-toggle="dropdown" 
    aria-haspopup="true" aria-expanded="false">
        My Favorite Heroes
    </a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
        <a class="dropdown-item" href="#">D.Va</a>
        <a class="dropdown-item" href="#">Lucio</a>
        <a class="dropdown-item" href="#">Reaper</a>
    </div>
</li>
```
Turns into (for the homepage):
```html
<li class="nav-item">
    <a class="nav-link" href="stats.html">My Stats</a>
</li>
<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="http://example.com" 
    id="navbarDropdownMenuLink" data-toggle="dropdown" 
    aria-haspopup="true" aria-expanded="false">
        My Favorite Heroes
    </a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
        <a class="dropdown-item" href="dva.html">D.Va</a>
        <a class="dropdown-item" href="lucio.html">Lucio</a>
    </div>
</li>
```

### Step 3: Cloning
We were instructed to clone our remote repositories to a different drive. I decided to clone my remote repo to my laptop. I will be working on some of my work from locations away from my desk so I will need this repo anyway, two birds with on stone!
First, I navigated to the My Documents folder and launched git bash.
The following bash is an example of how I cloned my code to my laptop.
```bash
mkdir SeniorProject
cd SeniorProject
git clone https://github.com/skoliver89/skoliver89.github.io
```
The SeniorProject directory now contains a clone of the skolier89.github.io repository. As an important note, one must be sure to pull the remote repo when switching to a different machine and to push any changes that are need to be saved prior to leaving the old machine.

### Step 4: GitHub Pages and Journal Entry

This step was simple. All I did was go into the remote repo's settings and make sure that github pages was active and selected a theme. As for the journal entries, I added index.md files to the main repo folder and the HW1 folder. The main index file contains an intro the the portfolio and links to the assignments. Within the HW1 index file I created the content you are reading now! I then, as before, added, commited, and pushed the index files and github pages took care of the rest.

[back to portfolio](https://skoliver89.github.io)