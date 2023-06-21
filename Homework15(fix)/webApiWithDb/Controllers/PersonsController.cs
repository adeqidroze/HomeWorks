using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System;
using Database.Data;
using Database.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly PersonContext p_context;
        public PersonsController(PersonContext personContext)
        {
            p_context = personContext;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            p_context.Persons.Add(person);
            await p_context.SaveChangesAsync();
            return CreatedAtAction("GetPersons", new { id = person.Id }, person);
        }

        [HttpGet("GetPersons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await p_context.Persons.ToListAsync();
        }

        [HttpGet("GetAddresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await p_context.Addresses.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Person>> PutPerson(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            p_context.Persons.Update(person);
            await p_context.SaveChangesAsync();
            return CreatedAtAction("GetPersons", new { id = person.Id }, person);
        }


        [HttpGet("GetPersons/{id}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsById(int id)
        {
            return await p_context.Persons.Where(x => x.Id == id).ToListAsync();
        }

        [HttpGet("GetAddresses/{id}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressesById(int id)
        {
            return await  p_context.Addresses.Where(x => x.Id == id).ToListAsync();
        }

        [HttpGet("GetAddressesByCondition")]
        public async Task<ActionResult<IEnumerable<Person>>> GetAddressesByCondition()
        {
            double maxPersonSalary=0;
            double prevPerson = 0;
            foreach (var person in p_context.Persons)
            {
                maxPersonSalary = Math.Max(prevPerson, person.Salary);
                prevPerson = person.Salary;
            }
            return await  p_context.Persons.Where(x => x.Salary == maxPersonSalary).ToListAsync();
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Person>>> DeletePerson(int id)
        {
            var RowToRemove = p_context.Persons.SingleOrDefault(x => x.Id == id); 

            if (RowToRemove != null)
            {
                p_context.Persons.Remove(RowToRemove);
                p_context.SaveChanges();
            }
            return await p_context.Persons.ToListAsync();
            //return await p_context.Persons.Where(x => x.Salary == maxPersonSalary).ToListAsync();
        }


    }

    public class PersonModel  
    {
        public DateTime CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperince { get; set; }
        public Address PersonAddress { get; set; }
        public int AddressId { get; set; }
    }


       
    /*



        [HttpGet("getPerson/{id}")]
        public IActionResult GetPersonById(int id)
        {
            var getByIdResult = JsonDese.JDeserializer(filePath).Where(x=>x.Id == id);

            if (getByIdResult.Count() == 0)
                return BadRequest($"Person with Id {id} does not exist.");

            return Accepted(getByIdResult.First()); 
        }

        [HttpGet("getPersons/withFilter")]
        public IActionResult GetpersonByFilter(string filterType, string input )
        {
            var myPersons = JsonDese.JDeserializer(filePath);
            var prevPerson = 0.0;
            var maxPersonSalary = 0.0;
            foreach (var person in myPersons)
            {                  
                maxPersonSalary = Math.Max(prevPerson, person.Salary);
                prevPerson = person.Salary;
            }
           // var getBiggestSalary = JsonDese.JDeserializer(filePath).Where(x => ));
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
        }*/
   
}
