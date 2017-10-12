using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalc
{
    /// <summary>
    /// Class to implement a singly linked stack
    /// </summary>
    class LinkedStack<T> : IStackADT<T>
    {
        private Node<T> top;

        public LinkedStack()
        {
            top = null; //Empty stack condition
        }

        public T push(T newItem)
        {
            Node<T> newNode = new Node<T>(newItem, top);
            top = newNode;

            return newItem;
        }

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

        public T peek()
        {
            if (isEmpty())
            {
                throw new Exception("Stack Empty!");
            }
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }

        public void clear()
        {
            top = null;
        }
    }
}
