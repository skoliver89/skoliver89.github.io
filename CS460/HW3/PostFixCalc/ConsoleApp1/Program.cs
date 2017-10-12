using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostFixCalc
{
    class Program
    {   //Create a new empty stack
        private static LinkedStack<double> myStack = new LinkedStack<double>();

        /// <summary>
        /// The main method for the PostFix Calculator
        /// </summary>
        /// <param name="args">Comand Line Args (unused)</param>
        static void Main(string[] args)
        {
            //Tell the user what is expected
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            bool playAgain = true;
            while (playAgain)
            {
                playAgain = DoCalculation();
            }
            Console.WriteLine("Bye.");
        }

        static bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            Console.Write("> "); //Prompt the User

            //Get space deliminated user input and add to an array of strings
            string input = Console.ReadLine();
            string output = "Empty output";
            //See if the user wishes to quit
            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }
            //Go go gadget calculator!
            try
            {
                output = EvaluatePostFixInput(input);
                //Write the outputline to the console
                Console.WriteLine("\n\t>>> " + input + " = " + output);
            }
            catch (Exception e)
            {
                //TODO: Exception handling.
                Console.WriteLine(e.Message);
            }

            return true;
        }

        static string EvaluatePostFixInput(string input)
        {
            string output = "";
            //Handle null or empty input strings by throwing an argument exception
            if (input == null || input.Length == 0)
            {
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            }
            //clear the stack prior to doing a new calculation
            myStack.clear();
            //put the input string elements into a temp array on whitespace
            Regex rgx = new Regex(@"\s+");
            string[] arr = rgx.Split(input);
            /* iterate through the array, pushing numbers into the stack
             * until the element is an operator, then to a calculation
             * and push the answer into the stack 
             */
            foreach (string element in arr)
            {
                if (IsOperator(element))
                {
                    myStack.push(DoOperation(element));
                    try
                    {
                        myStack.push(DoOperation(element));
                    }
                    catch(DivideByZeroException e)
                    {
                        throw new DivideByZeroException("Divide by Zero Error!" + e.Source);
                    }
                }
                else if (IsNumber(element))
                {
                    //push to stack
                    myStack.push(Convert.ToDouble(element));
                }
                else
                {
                    throw new ArgumentException(element + " is not a valid number or operand.");
                }
            }
            output = myStack.pop().ToString();
            if (myStack.isEmpty())
            {
                return output;
            }
            else
            {
                throw new Exception("Invalid number to operand ratio: " + input);
            }
        }

        static bool IsOperator(string s)
        {
            Regex rgx = new Regex(@"^[+*/-]$");
            if (rgx.IsMatch(s)) //test if the element is a math operator (* + - /)
            {
                return true; //is an operator
            }
            return false; //is not and operator
        }

        static bool IsNumber(string s)
        {
            Regex rgx = new Regex(@"^[-|+]?(?:\d*\.)?\d+$");
            if (rgx.IsMatch(s))
            {
                return true; //is a number
            }
            return false; //is not a number
        }

        static double DoOperation(string op)
        {
            double answer = 0;
            double b = myStack.pop();
            double a = myStack.pop();
            switch (op)
            {
                case "+":
                    answer = a + b;
                    break;
                case "-":
                    answer = a - b;
                    break;
                case "*":
                    answer = a * b;
                    break;
                case "/":
                    answer = a / b;
                    break;
            }

            return answer;
        }
    }
}
