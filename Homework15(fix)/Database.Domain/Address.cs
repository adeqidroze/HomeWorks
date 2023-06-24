using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Database.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HomeNumber { get; set; }
        [JsonIgnore]
        public List<Person> Persons = new List<Person>();
        
    }
}
