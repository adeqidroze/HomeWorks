using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPApp
{
    public class Company
    {
        public bool isLocal;

        public static double TaxToPay(bool origin, double amount) 
        {
            if (origin == true)  
                return amount * 0.82; 
            else
                return amount * 0.95;
        }
    }
}
