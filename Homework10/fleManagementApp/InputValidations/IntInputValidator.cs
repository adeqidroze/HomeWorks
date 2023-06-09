using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fleManagementApp
{
    public class IntInputValidator
    {
        static Boolean TypeFinder(string input)
        {
            var findInputType = "String";

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

        public static int inputValidator()
        {
            
            {
                Console.WriteLine("\nPlease enter a number:");
                var myInput = Console.ReadLine();
                if (TypeFinder(myInput) == false)
                {
                    Console.WriteLine($"{myInput} - This is wrong input! Try again!");
                    return inputValidator();
                }
                else
                {
                    return Int32.Parse(myInput);
                }
            }
        }

    }
}
