using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalc
{
    class Program
    {
        //Create a new empty stack
        private LinkedStack<double> stack = new LinkedStack<double>();

        /// <summary>
        /// The main method for the PostFix Calculator
        /// </summary>
        /// <param name="args">Comand Line Args (unused)</param>
        static void Main(string[] args)
        {
            //Tell the user what is expected
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            bool playAgain = true;
            while(playAgain)
            {
                playAgain = doCalculation();
            }
            Console.WriteLine("Bye.");            
        }

        static bool doCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            Console.Write("> "); //Prompt the User

            //Get space deliminated user input and add to an array of strings
            string[] input = Console.ReadLine().Split(' ');

            //See if the user wishes to quit
            if(input[0].StartsWith("q") || input[0].StartsWith("Q"))
            {
                return false;
            }

            //Go go gadget calculator!
            try
            {

            }
            catch
            {

            }


            return true;
        }
    }
}