using System;

namespace ConsoleAppTasks
{
    internal class Program
    {
        public static Double input;
        public static Double MinInput;
        public static Double MaxInput;

        //helper methods
        static Boolean TypeFinder(string input)
        {
            string findInputType = "String";

            if (!string.IsNullOrEmpty(input))
            {
                int inputInt;
                double inputDouble;

                if (Int32.TryParse(input, out inputInt))
                {
                    findInputType = "Int";
                    return true;
                }
                else if (Double.TryParse(input, out inputDouble))
                {
                    findInputType = "Double";
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

        static void inputValidator()
        {
            Console.WriteLine("\nPlease enter a number:");
            var myInput = Console.ReadLine();
            if (TypeFinder(myInput) == false)
            {
                Console.WriteLine($"{myInput} - This is wrong input! Try again!");
                inputValidator();
            }
            else
            {
                input = Double.Parse(myInput);
            }
        }

        /*
        public static void TryAgainQuestion(Func<string> func)
        {
            Console.WriteLine("Wanna try one more time?(Y/N)");
            var yesOrNo = Console.ReadLine();
            if (yesOrNo == "y" || yesOrNo == "Y") { var result = func; }
            else if (yesOrNo == "n" || yesOrNo == "N") { return; }
            else
            {
                Console.WriteLine(@"Wrong input!! I guess you did not wanted to try again anyway
        s0o, lets move on :D ");
                TryAgainQuestion(func);
            }
        }
        */
        static void MinMax(double myDub1, double myDub2) 
        {
                if (myDub1 > myDub2)
            {
                Console.WriteLine($"{myDub1} > {myDub2}");
                MinInput = myDub2; MaxInput = myDub1;
            }                
                else if( myDub1 < myDub2)
            {
                Console.WriteLine($"{myDub2} > {myDub1}");
                MinInput = myDub1; MaxInput = myDub2;
            }       
                else
            {
                Console.WriteLine("Your inputs are equal.");
                MinInput = myDub1; MaxInput = myDub2;
            }
        }


        //homework
        static void DevisionByFive() 
        {
            inputValidator();
            var firstInput = input;
            input = 0.1;

            if (firstInput % 5 == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static void AllOperations()
        {
            Console.WriteLine("Numbero UNO");
            inputValidator();
            var num1 = input;
            input = 0.2;

            Console.WriteLine("Numbero DOS");
            inputValidator();
            var num2 = input;
            input = 0.3;

            MinMax(num1, num2);
            var add =num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {add}");

            var sub = MaxInput - MinInput;
            Console.WriteLine($"{MaxInput} - {MinInput} = {sub}");

            var mult = num1 * num2;
            Console.WriteLine($"{num1} * {num2} = {mult}");

            if (MinInput == 0) 
            {
                Console.WriteLine("Not Allowed To Divide By Zero");
            }
            else 
            {
                var div = MaxInput / MinInput;
                Console.WriteLine($"{MaxInput} / {MinInput} = {div}");
            }
        }

        static void Swapper()
        {
            inputValidator();
            var x = input;
            input = 0.4;

            inputValidator();
            var y = input;
            input = 0.5;

            Console.WriteLine($"X = {x} and Y = {y}\nAfter swap:");

            // way #1
            var temp = x;
            x = y ; y = temp;
            Console.WriteLine($"Way #1:\nX = {x} and Y = {y}");

            // way #2
            x = x + y; y = x - y; x = x - y;
            Console.WriteLine($"(returned to original)\nX = {x} and Y = {y}\nAfter swap:");
            x = x + y; y = x - y; x = x - y;
            Console.WriteLine($"Way #2:\nX = {x} and Y = {y}");

        }

        static void MultiTable() 
        {
            inputValidator();
            var loopInput = input;
            input = 0.6;

            for(int i = 1 ; i < 10; i++) 
            {
                var multiTemp = loopInput * i;
                Console.WriteLine($"{loopInput} * {i} = {multiTemp}");
            }
        }

        static void Powerification() 
        {
            inputValidator();
            var squareInput = input;
            input = 0.6;


            for (int i = 1; i < squareInput; i++)
            {
                if (i % 2 == 0) 
                {
                    var squaredTemp = Math.Pow(i,2);    
                    Console.WriteLine($"{i} ^ 2 = {squaredTemp}");
                }  
            }
        }


        //launcher
        static void Main(string[] args)
        {

            Console.WriteLine(@"                                Hello and welcome to this code. 
                                Today , we are going to play with numbers!
                                Good luck!

                                First let me guess if your number is devided by 5.");

            //--------------------------------------------------------------------------------------------------
            DevisionByFive();//assignment 1

            Console.WriteLine("Wanna try one more time?(Y/N)");
            var yesOrNo = Console.ReadLine();

            if (yesOrNo == "y" || yesOrNo == "Y") 
            {
                DevisionByFive();
            }
            else if (yesOrNo == "n" || yesOrNo == "N") 
            {
                Console.WriteLine(@"                                Now lets move to the next one, shall we?!
                                Let's make all possible operations on any two number you choose!");
            }
            else { 
                Console.WriteLine(@"Wrong input!! I guess you wanted to try again anyway
    s0o, lets do it :D ");
                DevisionByFive();
            } //wamted to write a methd and got stuck (how to make method a parameter (TryAgainQuestion)) 

            //--------------------------------------------------------------------------------------------------
            AllOperations();//assignment 2

            Console.WriteLine("Wanna try one more time?(Y/N)");
            yesOrNo = Console.ReadLine();

            if (yesOrNo == "y" || yesOrNo == "Y")
            {
                AllOperations();
            }
            else if (yesOrNo == "n" || yesOrNo == "N")
            {
                Console.WriteLine(@"                                Ou! Moving fast, are not we?!
                                Let's now swap values of x and y. You ready?");
            }
            else
            {
                Console.WriteLine(@"Wrong input!! I guess you wanted to try again anyway
    s0o, lets do it :D ");
                AllOperations();
            }

            //--------------------------------------------------------------------------------------------------
            Swapper();//assignment 3

            Console.WriteLine("Wanna try one more time?(Y/N)");
            yesOrNo = Console.ReadLine();

            if (yesOrNo == "y" || yesOrNo == "Y")
            {
                Swapper();
            }
            else if (yesOrNo == "n" || yesOrNo == "N")
            {
                Console.WriteLine(@"                                Now we talking!
                                Let's play with for loops and write whole multiplication table for your number!");
            }
            else
            {
                Console.WriteLine(@"Wrong input!! I guess you wanted to try again anyway
    s0o, lets do it :D ");
                Swapper();
            }

            //--------------------------------------------------------------------------------------------------
            MultiTable();//assignment 4

            Console.WriteLine("Wanna try one more time?(Y/N)");
            yesOrNo = Console.ReadLine();

            if (yesOrNo == "y" || yesOrNo == "Y")
            {
                MultiTable();
            }
            else if (yesOrNo == "n" || yesOrNo == "N")
            {
                Console.WriteLine(@"                                Everything going fine, i hope?
                                And at last, lets power some stuff up, give me any number!");
            }
            else
            {
                Console.WriteLine(@"Wrong input!! I guess you wanted to try again anyway
    s0o, lets do it :D ");
                MultiTable();
            }

            //--------------------------------------------------------------------------------------------------
            Powerification(); //assignment 5

            Console.WriteLine(@"                                At last we are here!!!
                                I am jus going to ask you one last thing ...
                                Wanna try all thsi again? (i had fun though)(Y/N)");
            yesOrNo = Console.ReadLine();

            if (yesOrNo == "y" || yesOrNo == "Y")
            {
                Console.WriteLine("Just kidding, bye");
            }
            else if (yesOrNo == "n" || yesOrNo == "N")
            {
                Console.WriteLine("bye");
            }
            else
            {
                Console.WriteLine("bye");
            }
            Console.WriteLine(@"                                $$$$$$$$$$$$$$$$$$$$$$$$$$$
                                $$$$$$$$$$$$$$$$$$$$$_____$
                                $_____$$$$$$$$$$$$$$$_____$
                                $_____$$$$$$$$$$$$$$$_____$
                                $_____$$____$$$____$$_____$
                                $_____$______$______$_____$
                                $_____$______$______$_____$
                                $_____$____$$$$$$$$$$$$$$$$
                                $_____$___$$___________$$$$
                                $_____$__$$_______________$
                                $__________$$_____________$
                                $___________$$___________$$
                                $_____________$_________$$$
                                $$_____________________$$$$
                                $$$___________________$$$$$
                                $$$$$$$$$$$$$$$$$$$$$$$$$$$
                                ");
        }
    }
}
