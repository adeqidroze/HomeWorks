using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }

        public List<Credential> Credentials = new();


    }
    public class SystemRoles
    {
        public const string Admin = "Admin";
        public const string Guest = "Guest";
    }
}
