using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fleManagementApp
{
    public class InputArrayStr
    {
        public string[] ArrayOfStringsValidator()
        {
            String[] myStrings;

            Console.WriteLine("please enter words (devide with spaces):");

            var myListInput = Console.ReadLine();

            myStrings = Regex.Matches(myListInput, "(-?[a-z]+)").Cast<Match>().Select(m => m.Value).ToArray();

            return myStrings;
        }

        public string[] ValidatedText()
        {
            Console.WriteLine("First, we need the number of lines.");
            var myinput = IntInputValidator.inputValidator();
            Console.WriteLine("Second, we need the words for lines.");
            var myArray = ArrayOfStringsValidator();

            if (myinput != myArray.Length)
            {
                Console.WriteLine(@"Array Length does not match the inputed number of lines!
                                  Try Again!!!");
                return ValidatedText();
            }
            else
            {
                return myArray;
            }

        }
    }
}
