using System;

namespace webApiWithDb.Models
{
    public class PersonDto
    {
        public DateTime CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperince { get; set; }
        public int AddressId { get; set; }
        //public Address PersonAddress { get; set; }

    }
}
