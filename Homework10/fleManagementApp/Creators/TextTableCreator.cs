using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fleManagementApp.Creators
{
    public class TextTableCreator
    {
        /*static public void GetTable(int num, string filePath)
        {
            using StreamWriter stWrite = new StreamWriter(filePath);
            using StreamReader sr = new StreamReader(filePath);

            for (int j = 1; j <= num; j++)
            {
                for (int i = 1; i < 10; i++)
                {                       
                    stWrite.WriteLine($"{j} * {i} = {num * i} |");
                }
            }
            stWrite.Close();
        }*/

        static public void GetTable(int num, string filePath)
        {
            using StreamWriter stWrite = new StreamWriter(filePath);
            string[] myMultytable ={};
            Array.Resize(ref myMultytable,9);

            for (int j = 1; j <= num; j++)
            {
                for (int i = 1; i < 10; i++)
                {
                    var result = (j > 1) ? myMultytable[i-1] = myMultytable[i-1] + $" {j} * {i} = {j * i} |" : 
                                                               myMultytable[i-1] = $" {j} * {i} = {j * i} |" ;
                }
            }

            foreach (var table in myMultytable) 
            { 
                stWrite.WriteLine(table); 
            }
            stWrite.Close();
        }
    }
   

}
