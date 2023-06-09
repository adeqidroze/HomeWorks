using fleManagementApp.InputValidations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace fleManagementApp.Creators
{
    public  class XMLCreator
    {
        

        public static void StringSplitter() 
        {
            var doc = new XmlDocument();
            var tempStringList =  new List<string> { };
            Console.WriteLine("We need a new string.");
            var splitableString = Console.ReadLine();
            Console.WriteLine("In how many pieces are we splitting the string?");
            var splitNumber =IntInputValidator.inputValidator();
            var devision = splitableString.Length / splitNumber;

            if (devision < 1)
            {
                Console.WriteLine($"The string can't be spitted into {splitNumber} pieces. Try Again!!!-");
                StringSplitter();
            }
            else
            {
                foreach(var item in Split(splitableString, devision))
                {
                    tempStringList.Add(item);
                }          
            }

            var path = FileNameCreator.name(".xml");
            FileCreator.CreateF(path);
            XmlWriter writer = XmlWriter.Create(path);
            writer.WriteComment("nikas xml file");
            writer.WriteStartElement("TestXmlFile");

            for(int i =0; i< tempStringList.Count;i++ )
            {

                XmlElement ce = doc.CreateElement(tempStringList[i].ToString());
                ce.InnerText = $"String {i}";
            }
            doc.Save(path);
            writer.Close();
        }


        static IEnumerable<string> Split(string str, int size)
        {
            return Enumerable.Range(0, str.Length / size)
                .Select(i => str.Substring(i * size, size));
        }


    }
}
