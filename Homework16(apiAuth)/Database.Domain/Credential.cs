using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain
{
    public class Credential
    {
        public int Id { get; set; } 
        public string Username { get; set; }    
        public string Password { get; set; } 
        public int PersonId { get; set; }
        public Person MyPerson { get; set; }
        public int RoleId { get; set; } 
        public  Role UserRole { get; set; }

    
    }
}
