using fleManagementApp.Creators;
using fleManagementApp.InputValidations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace fleManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var newobj = new InputArrayStr();
            string[] inputArray = newobj.ValidatedText();

            var filePath = FileNameCreator.name(".txt");
            FileCreator.CreateF(filePath);

            using StreamWriter stWrite = new StreamWriter(filePath);

            for (int i = 0; i < inputArray.Length; i++)
            {
                stWrite.WriteLine(inputArray[i]);
            }
            stWrite.Close();

            Console.WriteLine($"Your text file's last line is: {File.ReadLines(filePath).Last()}");

            //--------------------------------------------------------------------------------------


            Console.WriteLine("\n\n --------------------------------");
            Console.WriteLine("We need a new number for table.");
            var maxNumber = IntInputValidator.inputValidator();
            if (maxNumber >= 1)
            {
                filePath = FileNameCreator.name(".txt");

                FileCreator.CreateF(filePath);

                TextTableCreator.GetTable(maxNumber, filePath);            
            }
            else
            {
                Console.WriteLine("Number you entered was less than 1. Try Again!!!");
            }

            
            //--------------------------------------------------------------------------------------
            Console.WriteLine("\n\n --------------------------------");

            XMLCreator.StringSplitter();


            //--------------------------------------------------------------------------------------
            Console.WriteLine("\n\n --------------------------------");
             filePath = @"C:\Users\User\Source\Repos\adeqidroze\HomeWorks\Homework10\fleManagementApp\projextCreatedFiles\nikusha.json";
            using StreamReader r = new StreamReader(filePath);
            string json = r.ReadToEnd();
            var myJsonModel = JsonConvert.DeserializeObject<MyJsonModel>(json);                       
            var birthday = myJsonModel.birthdate.Split("-");
            var currentDay = myJsonModel.sysdate.Split("-");

            var month = 0;
            var day = 0;
            var year = 0;
            for (int i = 0; i < currentDay.Length; i++)
            {
                if (i == 0)
                {
                     month = int.Parse(birthday[i]) - int.Parse(currentDay[i]);
                }
                else if (i == 1)
                {
                     day = int.Parse(birthday[i]) - int.Parse(currentDay[i]);
                }
                else
                {
                     year = int.Parse(birthday[i]) - int.Parse(currentDay[i]);
                }
            }
            Console.WriteLine(day +" " +month +" "+ year);
            if (day < 0) 
            {
                day += 31 ; 
                month -= 1;
            }
            else if (month<0)
            { 
                month += 12; 
                year -= 1; 
            }

            Console.WriteLine((year * 365) + (month * 31) + day);


            
            //--------------------------------------------------------------------------------------
            Console.WriteLine("\n\n --------------------------------");

             filePath = @"C:\Users\User\Source\Repos\adeqidroze\HomeWorks\Homework10\fleManagementApp\projextCreatedFiles\cezarshipr.json";
            using StreamReader Srr = new StreamReader(filePath);
            string jsonCezar = Srr.ReadToEnd();
            var cezarJsonModel = JsonConvert.DeserializeObject<cezarShipr>(jsonCezar);
            var strCol = cezarJsonModel.word;
            var num =Convert.ToInt32(cezarJsonModel.key);
            var shophredCode = "";
            var limitOfLetters = 25;
            for (int i = 0; i < strCol.Length; i++)
            {
                if(i+num > limitOfLetters)
                {
                    shophredCode = shophredCode + strCol[i + num - limitOfLetters];

                }
                else
                {
                    shophredCode = shophredCode + strCol[i + num];
                }

            }
            Console.WriteLine(shophredCode);
        }
    }
}
