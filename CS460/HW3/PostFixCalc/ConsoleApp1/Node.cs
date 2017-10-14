using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalc
{
    /// <summary>
    /// C# Node class using Generics.
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    class Node<T>
    {
        public T data;         // The payload
        public Node<T> next;   // Reference to the next node

        /*
         * Omitting the Default constructor from
         * the Java version since I am using generics
         */
        
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

        /// <summary>
        /// Property for setting and getting (R/W) the data variable value
        /// </summary>
        public T Data
        {
            set { data = value; }
            get { return data; }
        }
        
        /// <summary>
        /// Property for setting and getting (R/W) the next variable value
        /// </summary>
        public Node<T> Next
        {
            set { next = value; }
            get { return next; }
        }
    }
}
