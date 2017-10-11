using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Method to pop an item off of the top of the stack.
        /// </summary>
        /// <returns>An item popped from the stack</returns>
        T pop();

        /// <summary>
        /// Method to look at the top item in the stack 
        /// without removing (popping) it.
        /// </summary>
        /// <returns></returns>
        T peek();

        /// <summary>
        /// Method to check if the stack is empty.
        /// </summary>
        /// <returns></returns>
        bool isEmpty();

        /// <summary>
        /// Method to reset the stack by emptying it.
        /// </summary>
        void clear();
    }
}
