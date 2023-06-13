using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPApp
{
    public class Employee
    {
        public enum Positions
        {
            PO,
            Dev,
            QA,
            CJ,
            SA
        }
        public string name;
        public string lastName;
        public int age;
        public Positions employeePos;
        public int[] workedHoursInWeek;

        public static double WeeklyIncome(Positions inPos, int[] hours)
        {
            var hourlyRate = 0;
            var workedHours = 0;
            double wIncome = 0;
            var weekendRate = 0;
            var stWorkingHours = 8;
            var overTimeRate = 5;
            var bonusAfterHours = 50;



            if (inPos == Positions.PO) //choosing hourly rate by position //better in method
                hourlyRate = 40; 
            else if (inPos == Positions.Dev)  
                hourlyRate = 30; 
            else if (inPos == Positions.QA)
                hourlyRate = 20; 
            else 
                hourlyRate = 10; 



            for (int i = 0; i < hours.Length; i++) //counting income depending on week days
            {
                if (i < 5)
                {
                    if (hours[i] <= stWorkingHours)
                    {
                        wIncome = wIncome + (hours[i] * hourlyRate);
                    }
                    else
                    {
                        wIncome = wIncome + ((hours[i] - stWorkingHours) * overTimeRate + (hourlyRate * stWorkingHours));
                    }
                }
                else
                {
                    weekendRate = hourlyRate * 2;
                    wIncome = wIncome + (hours[i] * weekendRate);
                }
            }

            foreach(int var in hours) //counting total hours
            {
                workedHours = workedHours + var;
            }

            if (workedHours > bonusAfterHours) //deciding if bonus is required
                wIncome = wIncome * 1.2;

            return wIncome;
        }

    }
}
