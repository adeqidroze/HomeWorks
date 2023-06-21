using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Database.Domain
{
    [DataContract]
    public class Person
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperince { get; set; }
        [JsonIgnore]
        public int AddressId { get; set; }      
        public Address PersonAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var valList = new List<ValidationResult>();
            if (Salary < 0 || Salary > 10000)
            {
                //valList.Add(new ValidationResult($"Invalid salary {Salary}. Range is from 0 to 10 000."));
                yield return new ValidationResult($"Invalid salary {Salary}. Range is from 0 to 10 000.");
            }
            if (CreateDate > DateTime.Now)
            {
                //valList.Add(new ValidationResult($"CreateDate can't be in future."));
                yield return new ValidationResult($"CreateDate can't be in future.");
            }
            if (Firstname.Length < 1 || Firstname.Length > 51)
            {
                //valList.Add(new ValidationResult($"Firstname length, should be between 0 - 50. Current length: {Firstname.Length}"));
                yield return new ValidationResult($"Firstname length, should be between 0 - 50. Current length: {Firstname.Length}");
            }
            if (Lastname.Length < 1 || Lastname.Length > 51)
            {
                //valList.Add(new ValidationResult($"Lastname length, should be between 0 - 50. Current length: {Lastname.Length}"));
                yield return new ValidationResult($"Lastname length, should be between 0 - 50. Current length: {Lastname.Length}");
            }
            if (JobPosition.Length < 1 || JobPosition.Length > 51)
            {
                //valList.Add(new ValidationResult($"JobPosition length, should be between 0 - 50. Current length: {JobPosition.Length}"));
                yield return new ValidationResult($"JobPosition length, should be between 0 - 50. Current length: {JobPosition.Length}");
            }
            if (PersonAddress.Country.Length < 1 || PersonAddress.Country == null)
            {
                yield return new ValidationResult("Country field in Address is empty or null.");
            }
            if (PersonAddress.City.Length < 1 || PersonAddress.City == null)
            {
                yield return new ValidationResult("City field in Address is empty or null.");
            }
            if (PersonAddress.HomeNumber.Length < 1 || PersonAddress.HomeNumber == null)
            {
                yield return new ValidationResult("HomeNumber field in Address is empty or null.");
            }
        }
    }
}
