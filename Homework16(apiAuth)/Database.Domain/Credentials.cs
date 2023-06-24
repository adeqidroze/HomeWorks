using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain
{
    public class Credentials
    {
        public int Id { get; set; } 
        public string Username { get; set; }    
        public string Password { get; set; } 
        public int PersonId { get; set; } 
        public Person Person { get; set; }
    }
}
