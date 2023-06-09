using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleOOPApp
{
    public class inputs
    {
        
        public static Boolean TypeFinder(string input)//function finding if input is int or not
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


        public static int singleInputValidator()//function for validating and returning from string input
        {
            Console.WriteLine("\nPlease enter a number:");
            var myInput = Console.ReadLine();
            if (TypeFinder(myInput) == false)
            {
                Console.WriteLine($"{myInput} - This is wrong input! Try again!");
                singleInputValidator();
            }
            else
            {
                return Int32.Parse(myInput);
            }
            return 0;

        }

        public static int[] inputArrayValidator(int size)//function for validating and returning array from string input
        {
            int[] returnArray = new int[size];
            Console.WriteLine($"\nPlease enter {size} array numbers (devide with spaces):");
            var myInput = Console.ReadLine();

            if (Regex.Matches(myInput, "(-?[0-9]+)").Count > size)
            {
                Console.WriteLine("Out Of Range!\nNumber of inputs exceeded array length!\nPlease try again!");
                inputArrayValidator(size);
            }
            else if (Regex.Matches(myInput, "(-?[0-9]+)").Count < size)
            {
                Console.WriteLine("Not Enough Numbers!\nNumber of inputs were less than array length!\nPlease try again!");
                inputArrayValidator(size);
            }
            else
            {
                returnArray = Regex.Matches(myInput, "(-?[0-9]+)").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
            }

            Console.WriteLine("Array Created:");

            return returnArray;
         
        }








    }
}
