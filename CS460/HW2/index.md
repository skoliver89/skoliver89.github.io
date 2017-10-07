---
title: Stephen Oliver
layout: default
---
## CS460 Homework 1 - Journal

Homework 2 is designed to famlilizrize the student with HTML forms, javascipt, and jQuerry. We are to create an html form that takes in data, uses javascript to do some calculation on the data, and present the answer back to the user. Also, we are supposed to style the page with CSS and Bootstrap. To plan out the design or our page, we are instructed to create a "wireframe mockup". Further, during the development of our page we are to work in a feature branch of our repo and merge back with the master branch upon completion.

Instructions for HW2 can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW2.html).

The Website I created can be viewed [here](https://skoliver89.github.io/CS460/HW2/hw2.html).

## Step 1: Create a new feature branch, an empty HTML file, and an empty CSS file

Once I was in the correct directory (CS460/HW2), I created my empty HTML and CSS files; I knew that I would absolutely need these files so added them to the master branch (empty).
```bash
echo "" > hw2.html
echo "" > styles.css
git add *
git commit -m "[message here]"
git push origin master
```
I elected to name what would normally be the index.html file as hw2.html so that I could keep the page in the same directory as my journal entry (index.md) and it would correctly load the journal page. I discovered in the last assignment that pages translates index.md to index.html so naming my HW2 site index.html would cause a conflict.

Next, I created a new feature branch to work in without messing up my master branch called "newFeature".
```bash
git branch newFeature
```
Then, I moved to the newFeature branch so that when I started writing code for my html, css, and js files they would occur on that branch and not master.
```bash
git checkout newFeature
```

To Finish off step 1 I pushed the new branch to my remote repo on git hub.
```bash
git push origin newFeature
```

## Step 2: Brainstorm an idea and create a wireframe for design

In order to keep the page simple as instructed I decided to design a property tax calculator. This is an extremely simple caculation, but I believe it will play well in the role of teaching me how to implement some javaScript into my pages. After some thought on the idea, I decided to add a little complexity by having the user select a state of residence from a drop-down menu. The home value would still be a simple text-field with some added type checking so that the user can't break the equation. The user will hit the "Calculate" button upon entering the data. If there is a black field I will need to present the user with a message informing them of their error. Also, tax rate data for the selected state will be read and selected from a file storing rates for all states in the U.S. The javaScript will the populate an image, if it has one, of the selected state's flag below the button. The answer to the calculation will populate below the flag. Finally, to add a nice finishing touch the page will display a youTube video (embedded) describing how property taxes are calcaculated at the bottom of the page.

To better Visualize my idea, I created a layout wireframe with a program called Pencil. 
![My Page's Wireframe](assets/wireframe.png)

Later, I noticed that the rates I will be using are the median rate so I need to add a note in the page footer to warn the user of this.

NOTE: I found the median rates [here](http://www.tax-rates.org/taxtables/property-tax-by-state)

## Step 3: Create the page


NOTE: To simplify for a proof of concept this version of the page will only work for the states: Washington, Oregon, and California.

## Step 4: Merge to master



[back to portfolio](https://skoliver89.github.io/)