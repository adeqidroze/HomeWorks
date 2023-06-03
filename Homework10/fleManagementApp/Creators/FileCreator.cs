using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fleManagementApp.Creators
{
    public  class FileCreator
    {
        public static void CreateF(string path)
        {
            if (!File.Exists(path))
            {
                StreamWriter cf = File.CreateText(path);
                cf.WriteLine("Nika's txt file");
                cf.Close();
            }
        }
    }
}
