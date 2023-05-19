using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsolAppRandomFunc
{
    internal class Program
    {
        static int input;
        public static int[] inputArray;
        public static string[] myStrings;

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

        static void ListValidator()
        {
            Console.WriteLine("please enter the words (devide with spaces):");

            var myListInput = Console.ReadLine();
         
            myStrings = Regex.Matches(myListInput, "(-?[a-z]+)").Cast<Match>().Select(m => m.Value).ToArray();
            
            Console.WriteLine("Array Created: ");
            foreach (var value in myStrings)
            {
                Console.Write($" {value}"+"\n");
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

        static void SquareArea(double circleRad)
        {
            double innerSqArea = Math.Pow(circleRad * 2, 2) / 2;
            double outerSqArea = Math.Pow(circleRad * 2, 2);
            double areaSub = outerSqArea - innerSqArea;
            Console.WriteLine($"\nthe substraction of our areas is: {areaSub}");
        }

        static void JeckpotChecker() 
        {
            ListValidator();
            for (int i = 1;i< myStrings.Length;i++)
            {
                if (myStrings[i] != myStrings[i - 1]) 
                {
                    Console.WriteLine("No JaclPot For You Today!!!\n");
                    break;
                }
                else if(myStrings[i] == myStrings[i-1] && i == myStrings.Length - 1)
                {
                    Console.WriteLine("YES! You Got JaclPot !!!\n");
                }
            }
        }

        static void NumberOfPoints()
        {
            Console.WriteLine("First tell us how many wins the team had?");
            inputValidator(false);
            int sum = input * 3;
            Console.WriteLine("Now lets say how many draws the team had?");
            inputValidator(false);
            sum = sum + input;

            Console.WriteLine("And last but not least, how many looses did the team have?");
            inputValidator(false);

            Console.WriteLine($"Your team has {sum} points.");

        }

        static void WeeklyIncome()
        {
            var wIncome = 0;
            var hourlyRate = 10;
            var stWorkingHours = 8;
            var overTimeRate = 5;
            var weekandRate = hourlyRate * 2;
            input = 7;
            inputValidator(true);
            for(int i = 0; i < inputArray.Length; i++)
            {
                if (i < 5)
                {
                    if (inputArray[i] <= stWorkingHours)
                    {
                        wIncome = wIncome + (inputArray[i] * hourlyRate);
                    }
                    else
                    {
                        wIncome = wIncome+((inputArray[i] - stWorkingHours) * overTimeRate + (hourlyRate* stWorkingHours));
                    }
                }
                else
                {
                    wIncome = wIncome + (inputArray[i] * weekandRate);
                }              
            }
            Console.WriteLine($"Your Weekly Income Is {wIncome}.");
        }

        static void GeorgeEvolve()
        {
            inputValidator(false);
            inputValidator(true);
            var improveDays = 0;

            for(int i = 1; i<inputArray.Length; i++)
            {
                if (inputArray[i] > inputArray[i - 1]) 
                { improveDays++; }
            }
            Console.WriteLine($"George's improvement days equal to  {improveDays}.");

        }


        static void AnyElementPrinter() 
        {
            inputValidator(false);
            ListValidator();
            var word = from x in myStrings
                       where  x.Length == input
                       select new {match = x};
            if(word.FirstOrDefault() != null) 
            {
                foreach (var value in word)
                {
                    Console.WriteLine($"\nYour word is :{value.match} ");
                }
            }
            else
            {
                Console.WriteLine("No Elements Found!");
            }
          
            

        }


        static void Main(string[] args)
        {
            Console.WriteLine("welvome to the program!\nsorry for a short intro buts lets get it started shall we?\ngive us a radius first.");
            inputValidator(false);
            SquareArea(input);
            Console.WriteLine("\nGood!\nNow lets check if you ar going to get a jackpot!");

            JeckpotChecker();
            Console.WriteLine("\nGreat!\nNow lets see how good is your soccer team!");

            NumberOfPoints();
            Console.WriteLine("\nGood team!\nNot to be rude but lets check your coworker's weekly income now!");

            WeeklyIncome();
            Console.WriteLine("\nDid not expect that!\nOkay, lets see how our georgy is doin!");

            GeorgeEvolve();
            Console.WriteLine("\nHard working guy!\nNow last but not least , lets play with words!");

            AnyElementPrinter();

            Console.WriteLine("thank you and bye!");
        }



    }
}
