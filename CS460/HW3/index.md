---
title: Stephen Oliver
layout: default
---
## CS460 Homework 3 - Journal

The primary of objectives of this assignment was to familizrize the student with Visual Studio and C#. The assignment also continues to hone the students' Git skills. The version of VS which will be used is the 2017 community edition. The C3 code written will be moderately complex and be written using standard C# conventions.
The overall requirement of this assignment is to effectively translate a postfix claculator program from Java to C#. The C# code must maintain, or exceed, the commenting in the original Java. Students are reminded to use command line git and NOT the git controls in Visual Studio 2017.

Instructions for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3.html).

There is no web interface for this assigment so a demo of the program will be contained within this journal entry. As always, the source code for this project can be found in the github repository connected to the above button.

## Step 1: Inspect the original Java source code and lab document

Upon inspecting the Java code and documentation I discovered that the Java code is a solution for a post fix calculator. This source code includes an Interface/ADT (Abstract Data Type) file, a generic definiton of linked nodes and a linked stack using object encapsulation. The jusification for the encapsulation instead of generic data types is that java, at that time, did not support generic typing. Considering that I will be translating the application to C# I decided, with the help of a fellow classmate, that I would go ahead and setup the Interface, Node, and Linked Stack using generic data typing rather than object encapsulation. This decision was reached in order to improve efficiency of the overall application and to make the node and stack classes more easily ussable in other projects. Further inspection into the calculator code I discovered pretty robust error detection and handling on top of a command line interface. Aside from a few cosmetic changes I kept the interface and error handling as close to the original as possible.

## Step 2: Translate the Interface



## Step 3: Translate the Node and Linked Stack classes



## Step 4: Translate the Postfix Calcualtor class

