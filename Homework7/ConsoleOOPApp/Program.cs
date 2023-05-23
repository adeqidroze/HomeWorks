using System;

namespace ConsoleOOPApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var week = 7;
            Company commSchool = new Company();
            commSchool.isLocal = true;

            double totalAmount = Company.TaxToPay(commSchool.isLocal, inputs.singleInputValidator());
            Console.WriteLine($"The total income of your company is {totalAmount}");

            Employee zura = new Employee();
            Console.WriteLine("Please enter employee name:");
            zura.name = Console.ReadLine();
            Console.WriteLine("Please enter employee lastname:");
            zura.lastName = Console.ReadLine();
            Console.WriteLine("We need to know the age too!");
            zura.age = inputs.singleInputValidator();
            zura.employeePos = Employee.Positions.QA;
            Console.WriteLine("Log employee's work hours during this week.");
            zura.workedHoursInWeek = inputs.inputArrayValidator(week);

            double employeeIncome = Employee.WeeklyIncome(zura.employeePos, zura.workedHoursInWeek);
            Console.WriteLine($"Your Weekly Income Is {employeeIncome}.");


        }
    }
}
