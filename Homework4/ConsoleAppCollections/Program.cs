using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleAppCollections
{
    internal class Program
    {
        public static int input;
        public static int[] inputArray;

        static Boolean TypeFinder(string input)         
        {
            string findInputType = "String";

            if (!string.IsNullOrEmpty(input))
            {
                int inputint;

                if (int.TryParse(input, out inputint)) 
                {
                    findInputType = "Int";
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        static void inputValidator(Boolean isArray)
        {
            if (isArray == true) 
            {
                Console.WriteLine($"\nPlease enter {input} array numbers (devide with spaces):");
                var myInput = Console.ReadLine();
               
                if (Regex.Matches(myInput, "(-?[0-9]+)").Count > input) 
                {
                    Console.WriteLine("Out Of Range!\nNumber of inputs exceeded array length!\nPlease try again!");
                    inputValidator(true);
                }
                else if (Regex.Matches(myInput, "(-?[0-9]+)").Count < input)
                {
                    Console.WriteLine("Not Enough Numbers!\nNumber of inputs were less than array length!\nPlease try again!");
                    inputValidator(true);
                }
                else
                {
                    inputArray = Regex.Matches(myInput, "(-?[0-9]+)").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
                }
                Console.WriteLine("Array Created:");
                foreach (var value in inputArray)
                {
                    Console.Write($" {value}");
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number:");
                var myInput = Console.ReadLine();
                if (TypeFinder(myInput) == false)
                {
                    Console.WriteLine($"{myInput} - This is wrong input! Try again!");
                    inputValidator(false);
                }
                else
                {
                    input = Int32.Parse(myInput);
                }
            }
        }

        static void oddAndEven() 
        {
            int[] oddArray = new int[] { };
            int[] evenArray = new int[] { };
            int n = 0, j=0;
            for (int i = 0; i < inputArray.Length; i++) 
            {
                if (inputArray[i] % 2 == 0)
                {
                    Array.Resize(ref evenArray, j + 1);
                    evenArray[j] = inputArray[i];
                    j=j+1;
                }
                else 
                {
                    Array.Resize(ref oddArray, n+1);
                    oddArray[n] = inputArray[i];
                    n=n+1;
                }
            }
            Console.WriteLine("\nEven array:");
            foreach (var value in evenArray) { Console.Write(" " + value);}
            Console.WriteLine("\nOdd array:");
            foreach (var value in oddArray) { Console.Write(" " + value); }

        }

        static void countDuplicates()
        {
            var counterBoy = from x in inputArray
                             group x by x into temp
                             let countDuplicates = temp.Count()
                             select new{DupValue = temp.Key, DupCount = countDuplicates, DupSum = temp.Key*countDuplicates };
            foreach (var value in counterBoy) 
            {
                Console.WriteLine($"\n{value.DupValue} appears {value.DupCount} times and sum is {value.DupSum}");
            }
        }

        static void topInClass() 
        {
            Array.Sort(inputArray);
            Console.WriteLine("\nAdd how many students from top you want to see.");
            inputValidator(false);

            Console.WriteLine("Our top student scores:");
            for(int i = inputArray.Length-1; i > inputArray.Length - (input+1); i--)
            {
                Console.WriteLine(inputArray[i]);
            }            
        }


        static void Main(string[] args)
        {
            Console.WriteLine(@"Welcome to homework4
                     Let's check odd and even numbers in our array
                     Lets see what is your array size first");
            inputValidator(false);
            Array.Resize(ref inputArray, input);
            inputValidator(true);
            oddAndEven();

            Console.WriteLine("\n");

            Console.WriteLine(@"Good!
                     Let's check our duplicates in your array
                     Lets see what is your array size first");
            inputValidator(false);
            Array.Resize(ref inputArray, input);
            inputValidator(true);
            countDuplicates();

            Console.WriteLine("\n");

            Console.WriteLine(@"Great!
                     Let's check Top scores of your students
                     Lets see what is your array size first");
            inputValidator(false);
            Array.Resize(ref inputArray, input);
            inputValidator(true);
            topInClass();

            Console.WriteLine("\nThanks bye.");

        }
    }
}
