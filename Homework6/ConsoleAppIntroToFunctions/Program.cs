using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleAppIntroToFunctions
{
    internal class Program
    {
        static int input;
        public static int[] inputArray;
        public static List<int> myInts = new List<int>();
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

        static void ListValidator(Boolean withLength)
        {
            Console.WriteLine("please enter the words (devide with spaces):");

            var myListInput = Console.ReadLine();

            myStrings = Regex.Matches(myListInput, "(-?[a-z]+)").Cast<Match>().Select(m => m.Value).ToArray();

            if(withLength == true) //would it be better if i used first if like:
                                   //(withlength == true && (myStrings.Length > input || myStrings.Length < input)) ?
            {
                if(myStrings.Length > input || myStrings.Length < input)
                {
                    Console.WriteLine($"Number of words does not match the needed number ({input}). Please try again");
                    ListValidator(true);
                }
            }
            Console.WriteLine("Array Created: ");
            foreach (var value in myStrings)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine("\n");
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

        static void InputIntervalValidator()
        {
            Console.Write("MIN: ");
            inputValidator(false);
            int a = input;
            Console.Write("MAX: ");
            inputValidator(false);
            int b = input;
            if (a > b)
            {
                Console.Write($"{a} is less than {b}! Try again!!");
                InputIntervalValidator();
            }
            else
            {
                Console.Write("POWER: ");
                inputValidator(false);
                IntervalChecker(a,b,input);
            }
        }
        static void IntervalChecker(int a,int b,int n)
        {
            var count=0;
           
            for(int i = a; i <= b; i++)
            {
                if(Math.Pow(i , 1 / (double)n) % 1 == 0)
                {
                    count++;
                }
            }

         Console.WriteLine(count);
        }

        static void LilNick(string pairs)
        {
            var sum = 0;
            var parameters = from x in pairs
                             group x by x into myPairs
                             let calculatePairs = myPairs.Count()
                             select new{Character = myPairs.Key, PairCount = calculatePairs};
            foreach (var pair in parameters)
            {
                sum = sum + pair.PairCount / 2;
            }
            Console.WriteLine(sum);               
        }
        /*  static string SameEndingChecker() 
          {
              input = 2;
              ListValidator(true);
              var mySimilarities = "" ;
              int j = myStrings[1].Length - 1;

              for (int i = myStrings[0].Length-1; i >= 0; i--)
              {
                  if(j >= 0)
                  {
                      if(myStrings[0][i] == myStrings[1][j])
                      {
                          mySimilarities = myStrings[0][i] + mySimilarities;
                      }
                      else return mySimilarities;
                  }
                  j--;
              }
              return mySimilarities;
          }*/

        static string SameEndingChecker()
        {
            Console.WriteLine("Please Enter a String: ");

            var firstString = Console.ReadLine();
            Console.WriteLine("Please Enter a String: ");

            var secondString = Console.ReadLine();

            var mySimilarities = "";
            int j = secondString.Length - 1;

            for (int i = firstString.Length - 1; i >= 0; i--)
            {
                if (j >= 0)
                {
                    if (firstString[i] == secondString[j])
                    {
                        mySimilarities = firstString[i] + mySimilarities;
                    }
                    else return mySimilarities;
                }
                j--;
            }
            return mySimilarities;
        }

        static void GenListTaker(List<string> data) 
        {
            foreach (string s in data) 
            {
                Console.WriteLine(s.ToUpper()); 
            }
        }
        static void GenListTaker(List<int> data)
        {
            var sum = 0;
            foreach (int i in data) { sum = sum + i;  }
            Console.WriteLine(sum);
        }
        static void GenListTaker(List<bool> data) 
        {
            Console.WriteLine($"First Element is {data[0]}");
            Console.WriteLine($"Last Element is {data[data.Count - 1]}");
            Console.WriteLine($"Middle Element is {data[data.Count / 2]}");
        }

        static int RecurNumber(int n) 
        {

            if(n == 0)
                return 0;

            myInts.Add(n % 10); 
            return RecurNumber(n / 10); 
        }


        static void Main(string[] args)
        {
            var temp = "";
            int i = 0;
            Console.WriteLine("\nFirst! root counter!");

            InputIntervalValidator();

            Console.WriteLine("\nSecond! little nick!");
            Console.WriteLine("Please Enter a String: ");

            LilNick(Console.ReadLine());

            Console.WriteLine("\nThird! same ending shower!");

            Console.WriteLine(SameEndingChecker());

            Console.WriteLine("\nFourth! generic lists!");

            List<string> strList = new List<string>() { "HeRe", "yOu", "gO" };
            List<int> intList = new List<int>() { 49, 16, 81, 121 };
            List<bool> boolList = new List<bool>() { true, true, false, true, false, false, false };
            GenListTaker(strList);
            GenListTaker(intList);
            GenListTaker(boolList);

            Console.WriteLine("\nFifth! recursive printer!");

            inputValidator(false);
            RecurNumber(input);
            foreach(int val in myInts)
            {
                if (i == 0) { temp = val.ToString(); }
                else { temp = val.ToString() + " - " + temp; }              
                i++;
            }
            Console.WriteLine(temp);
        }
    }
}
