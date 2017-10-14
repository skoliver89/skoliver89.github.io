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

Original Name: StackADT.java <br />
Translated Name: IStack.cs <br />

This fies is the interface for the methods used in the Linked Stack. The full name of the interface is IStackADT\<T\> using the namespace PostFixCalc. This interface defines the Linked Stack's method signatures and contains the xml comments for each of the aforementioned methods. The T attached to the interface name indicates that the Linked Stack uses generic typing.
Here is a code snippet of what IStack looks like:
```c#
//...
namespace PostFixCalc
{
    /// <summary>
    /// C# Interface defining a stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStackADT<T>
    {
        /// <summary>
        /// Method to push a genericly typed new item to the stack
        /// </summary>
        /// <param name="newItem">A generic new item to push</param>
        /// <returns>A reference to the new item</returns>
        T push(T newItem);
//...
```
Note: to view the full code see the HW3 directory in the linked repository at the top of the page.

## Step 3: Translate the Node and Linked Stack classes
### A - Node
Original Name: Node.java <br />
Translated Name: Node.cs <br />

The Node source code was fairly easy to translate from Java to C#. The only differences was turing the comments into XML comments, the properites that C# is able to make use of, and that I did not need to write a default (empty) constructor.
Commenting in XML, as seen in the interface source code above, is estremely easy to accomplish in Visual Studio, just hit the "/" key three times and the editor auto-formats the comment block for you.
The following code snipet shows an XML comment for the Node class and its constructor.
```c#
/// <summary>
/// Constructor for a new Node object
/// </summary>
/// <param name="data">The Payload</param>
/// <param name="next">Reference to the next node</param>
public Node(T data, Node<T> next)
{
    this.data = data;
    this.next = next;
}
```
All that is accomplished in this simple constructor is setting the variables of the node.
As previously stated, C# is able to utilize properties. These properties allow for easy "getting" and "setting" of values held in a class. The following code snippet demonstrates how to write a property for the Node's data variable.
```c#
/// <summary>
/// Constructor for a new Node object
/// </summary>
/// <param name="data">The Payload</param>
/// <param name="next">Reference to the next node</param>
public Node(T data, Node<T> next)
{
    this.data = data;
    this.next = next;
}
```
This property is a read/write property, as is the property for the next variable. To make a property read-only simply ommit the set line.

### B - Linked Stack
Original Name: LinkedStack.java <br />
Translated Name: LinkedStack.cs <br />

The Linked Stack was also fairly easy to translate into C#. The only issues that I encountered was handling the behavior in the pop and peek methods for if the stack is empty. The class is pretty basic; it implements the push, pop, peek, isEmpty, and clear methods. The constructor simply initiates the stack as being empty (i.e. the top node is equal to null). The class is of the same namespace as the previous files, PostFixCalc, and implements/extends the IStackADT\<T\> interface.

The push method takes in a value to be stored and creates a new node to carry that value. The new node links itself to the current top node by reference and then makes itself the top node. Finally, the method returns the value that was pushed to the stack.
Here is what the code looks like:
```c#
public T push(T newItem)
{
    Node<T> newNode = new Node<T>(newItem, top);
    top = newNode;

    return newItem;
}
```

The pop method retrieves the data payload of the top node and then removes that node from the stack, making the node bellow it the new top node. The method then returns the value that was popped off of the stack. If pop is used on an empty stack the method will throw an exception with the message, "Stack Empty!"
```c#
public T pop()
{
    T topItem = top.data;
    if (isEmpty())
    {
        throw new Exception("Stack Empty!");
    }
    top = top.next;
    return topItem;
}
```

The peek method is similar to the pop method except it does not remove and replace the top node. It handles an empty stack in the same way as pop.
```c#
public T peek()
{
    if (isEmpty())
    {
        throw new Exception("Stack Empty!");
    }
    return top.data;
}
```
Note: I decided to throw and exception if the stack was empty in pop and peek instead of returning a null like in the original Java since I am using generics in place of the object encapsulation. My reasoning behind this is that with generics I cannot return a null since it is possible to initialize a generic as a numberic type, C# does not support null as a value for numerics, and I would have to use the default value in the place of null. The default of a numberic is the value 0 (zero) which is a vaild value, hence throwing the exception.

The last two methods, isEmpty and clear, are both carbon copies of the Java code. They are extremely simple; isEmpty returns a boolean true if the stack is empty and clear resets the stack to an empty state by setting the value of the top variable to null.
```c#
public bool isEmpty()
{
    return top == null;
}

public void clear()
{
    top = null;
}
```

## Step 4: Translate the Postfix Calcualtor class


## ---DEMO---