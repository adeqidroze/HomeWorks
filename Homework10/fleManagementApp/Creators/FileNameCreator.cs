using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fleManagementApp.InputValidations
{
    public class FileNameCreator
    {
        public static String name(string extension)
        {
            Console.WriteLine("Please enter the file name you want to find or create: ");
            return @"C:\Users\User\Source\Repos\adeqidroze\HomeWorks\Homework10\fleManagementApp\projextCreatedFiles\" + Console.ReadLine() + extension;
        }
    }
}
