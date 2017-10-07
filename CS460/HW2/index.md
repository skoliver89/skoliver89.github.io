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



## Step 3: Create the page



## Step 4: Merge to master



[back to portfolio](https://skoliver89.github.io/)