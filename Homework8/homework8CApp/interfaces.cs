using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8CApp
{
    public interface FinanceOperations
    {
        public double CalculateLoanPercent(int month, double AmountPerMonth);
        public bool CheckUserHistory();
    }

    public class Bank : FinanceOperations { 
        public bool CheckUserHistory()
        {
            var random = new Random();
            bool randomBool = random.Next(2) == 1;
            
            return randomBool;
        }
        public double CalculateLoanPercent(int month, double AmountPerMonth)
        {
            return AmountPerMonth * month * 0.05;
        }
    }
    public class MicroFinance : FinanceOperations {
        public bool CheckUserHistory()
        {
            return true;
        }
        public double CalculateLoanPercent(int month, double AmountPerMonth)
        {
            return (AmountPerMonth * 0.1 + 4) * month;
        }
    }
}
