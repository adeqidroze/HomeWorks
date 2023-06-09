using System;

namespace homework8CApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var monthlyPayment = 1543.78;
            var months = 123;

            Console.WriteLine("You owe Nick's bank in interest:");

            var BankOfNick = new Bank();
            if (BankOfNick.CheckUserHistory() == true)
                Console.WriteLine(BankOfNick.CalculateLoanPercent(months, monthlyPayment));

            Console.WriteLine("\nYou owe scam bank in interest:");

            var scamBank = new MicroFinance();
            Console.WriteLine(scamBank.CalculateLoanPercent(months, monthlyPayment));
        }
    }
}
