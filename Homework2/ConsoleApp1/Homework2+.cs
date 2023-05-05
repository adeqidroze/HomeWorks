//consol application  Nikoloz Kurashvili
//Homework 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    internal class ConsoleAppClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!\nMy name is Nikoloz Kurashvili");//Print Your Name

            Console.BackgroundColor = ConsoleColor.Blue;//Setting console color
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please enter any input: ");//Entering input
            var firstInput = Console.ReadLine();

            Console.WriteLine("your input was " + firstInput);//Printing input

            LeaveOrNot();//something extra
        }







        public static void LeaveOrNot() 
        {
            string AnswerInput = "";
            Console.WriteLine("\nDo you want to see a rainbow?(y/n)");
            AnswerInput = Console.ReadLine();

            if (AnswerInput == "Y" || AnswerInput == "y")//making small loops for answer choices
            {
                LittleTooExtra();
            }
            if (AnswerInput == "N" || AnswerInput == "n")
            {
                Environment.Exit(0);
            }
            else 
            { 
                Console.WriteLine("Wrong input Try again!"); 
                
                LeaveOrNot();//calling multiple choice question function again
            }
        }

        public static  void LittleTooExtra()//same homework but more colorful
        {
            Console.BackgroundColor = GetConsoleColor();//Setting console color

            Console.WriteLine("Wellcome!\nMy name is Nikoloz Kurashvili and this is my little cnsole app!");//Print Your Name

            Console.BackgroundColor = GetConsoleColor();//Setting console color
            

            Console.WriteLine("Please enter any input: ");//Entering input
            Console.BackgroundColor = GetConsoleColor();//Setting console colo

            var firstInput = Console.ReadLine();

            Console.BackgroundColor = GetConsoleColor();//Setting console colo


            Console.WriteLine("your input was " + firstInput);//Printing input

            Console.BackgroundColor = ConsoleColor.Black;//Setting console colo

            LeaveOrNot();//calling multiple choice question function
        }

        public static Random randomCol = new Random();//declaring new variable
        public static ConsoleColor GetConsoleColor()//rainbow function
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));//getting all valures of console colors
            return (ConsoleColor)consoleColors.GetValue(randomCol.Next(consoleColors.Length));//using random function to get random values from consoleColors
        }

    }
}







