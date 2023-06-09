using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace FirstWebApi.JsonDeserializer_Serializers
{
    public class JsonSeri
    {
        public static List<Persons> JSerializer(string filePath, List<Persons> myPersons)
        {
            using StreamWriter sw = new StreamWriter(filePath);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(sw, myPersons);
            sw.Close();
             
            return myPersons;
        }

        

    }
}
