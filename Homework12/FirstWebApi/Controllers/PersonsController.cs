using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using FirstWebApi.JsonDeserializer_Serializers;
using FirstWebApi.Models;
using System;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        readonly string filePath = @"C:\Users\User\Source\Repos\adeqidroze\HomeWorks\Homework12\FirstWebApi\Jsons\person collection.json";

        [HttpPost("createPersons")]
        public IActionResult CreatePersons(Persons person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
          
            var myPersons = JsonDese.JDeserializer(filePath);
            
            if(myPersons != null)
            {
                var result = from x in myPersons where x.Id == person.Id select x;

                if (result.Any())
                {
                    return BadRequest($"Person by Id {person.Id} already exists.\n");
                }
                else 
                {
                    myPersons.Add(person);
                }
            }
            else 
            {
                myPersons.Add(person);
            }

            return Accepted(JsonSeri.JSerializer(filePath, myPersons));
            //AcceptedAtActionResult createResult = $"Person with Id {person.Id} has been created.\n" ;
        }

        [HttpPut("updatePersons")]
        public IActionResult UpdatePersons(Persons person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var myPersons = JsonDese.JDeserializer(filePath);

            if (myPersons != null)
            {
                var result = from x in myPersons where x.Id == person.Id select x;

                if (result.Any())
                {
                    myPersons.Remove(result.First());
                    myPersons.Add(person);
                }
                else
                {
                    myPersons.Add(person);
                }
            }
            else
            {
                return BadRequest($"Person by Id {person.Id} does not exists.");
            }

            return Accepted(JsonSeri.JSerializer(filePath, myPersons));
            //return Accepted($"Person with Id {person.Id} has been updated.\n" + myPersons);
        }

        [HttpGet("gwtPersons")]
        public IActionResult GetPersons() 
        {           
            return Accepted(JsonDese.JDeserializer(filePath)); 
        }

        [HttpGet("getPerson/{id}")]
        public IActionResult GetPersonById(int id)
        {
            var getByIdResult = JsonDese.JDeserializer(filePath).Where(x=>x.Id == id);

            if (getByIdResult.Count() == 0)
                return BadRequest($"Person with Id {id} does not exist.");

            return Accepted(getByIdResult.First()); 
        }

        [HttpGet("getPersons/WithMyChoiceOfFilter:D")]
        public IActionResult GetpersonByFilter()
        {
            var myPersons = JsonDese.JDeserializer(filePath);
            var prevPerson = 0.0;
            var maxPersonSalary = 0.0;
            // same as max experience, also we can just get 
            foreach (var person in myPersons)
            {                  
                maxPersonSalary = Math.Max(prevPerson, person.Salary);
                prevPerson = person.Salary;
            }
            return Accepted(myPersons.Where(x=>x.Salary == maxPersonSalary).First());
        }

        [HttpDelete("deletePerson/{id}")]
        public IActionResult DeletePersonById(int id)
        {
            var myPersons = JsonDese.JDeserializer(filePath);

            var result = from x in myPersons where x.Id == id select x;

            if (!result.Any())
                return BadRequest($"Person with Id {id} does not exist.");
           
            myPersons.Remove(result.First());

            return Accepted(JsonSeri.JSerializer(filePath, myPersons));
        }
    }
}
