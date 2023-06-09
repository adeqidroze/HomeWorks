using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FirstWebApi.JsonDeserializer_Serializers
{
    public class JsonDese
    {
        public static  List<Persons> JDeserializer(string filePath)
        {
            using StreamReader r = new StreamReader(filePath);
            var json = r.ReadToEnd();
            var myPersons = JsonConvert.DeserializeObject<List<Persons>>(json);
            r.Close();
            return myPersons;
        }
          
    }
}
