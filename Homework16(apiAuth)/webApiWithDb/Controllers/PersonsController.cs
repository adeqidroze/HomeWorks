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
using webApiWithDb.Validators;
using FluentValidation;
using AutoMapper;
using webApiWithDb.Models;

namespace webApiWithDb.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PersonContext _context;
        public PersonsController(PersonContext personContext, IMapper mapper)
        {
            _mapper = mapper;
            _context = personContext;
        }

        // post metods
        [HttpPost]
        public async Task<ActionResult> PostPerson(PersonDto person)
        {
            var personValidator = new PersonValidator();
            var result = personValidator.Validate(person);

            if (result.IsValid)
            {
                var myPerson = new Person();
                _mapper.Map(person, myPerson);
                _context.Persons.Add(myPerson);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPersons", new { id = myPerson.Id }, person);
            }

            return BadRequest(result);

        }

        [HttpPost]
        public async Task<ActionResult> PostAddress(AddressDto address)
        {
            var addressValidator = new AddressValidator();
            var result = addressValidator.Validate(address);

            if (result.IsValid)
            {
                var myAddress = new Address();
                _mapper.Map(address, myAddress);
                _context.Addresses.Add(myAddress);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAddresses", new { id = myAddress.Id }, address);
            }
            return BadRequest(result);
        }



        // Get Methods
        [HttpGet("GetPersons")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            var person = await _context.Persons.ToListAsync();
            return _mapper.Map<List<PersonDto>>(person);
        }

        [HttpGet("GetAddresses")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses()
        {
            var address = await _context.Addresses.ToListAsync();
            return _mapper.Map<List<AddressDto>>(address);
        }



        // Put Methods
        [HttpPut("UpdatePerson/{id}")]
        public async Task<ActionResult> UpdatePerson(int id, PersonDto person)
        {
            var personValidator = new PersonValidator();
            var result = personValidator.Validate(person);

            if (result.IsValid)
            {
                var myPerson = await _context.Persons.FindAsync(id);

                if (myPerson == null)
                    return BadRequest($"Person with id = {id} doesn't exist.");

                _mapper.Map(person, myPerson);
                _context.Persons.Update(myPerson);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPersons", new { id = myPerson.Id }, person);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateAddress/{id}")]
        public async Task<ActionResult> UpdateAddress(int id, AddressDto address)
        {
            var addressValidator = new AddressValidator();
            var result = addressValidator.Validate(address);

            if (result.IsValid)
            {
                var myAddress = await _context.Addresses.FindAsync(id);

                if (myAddress == null)
                    return BadRequest($"Address with id = {id} doesn't exist.");

                _mapper.Map(address, myAddress);
                _context.Addresses.Add(myAddress);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAddress", new { id = myAddress.Id }, address);
            }
            return BadRequest(result);
        }



        // Get methods by id
        [HttpGet("GetPersons/{id}")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersonsById(int id)
        {
            var person = await _context.Persons.Where(x => x.Id == id).ToListAsync();
            if (person == null)
                return BadRequest("Person with id {id} doesn't exist.");

            return _mapper.Map<List<PersonDto>>(person);
        }

        [HttpGet("GetAddresses/{id}")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddressesById(int id)
        {
            var address = await _context.Addresses.Where(x => x.Id == id).ToListAsync();
            if (address == null)
                return BadRequest("Address with id {id} doesn't exist.");

            return _mapper.Map<List<AddressDto>>(address);
        }

        /*
        [HttpGet("GetAddressesByCondition")]
        public async Task<ActionResult<IEnumerable<Person>>> GetAddressesByCondition()
        {
            double maxPersonSalary=0;
            double prevPerson = 0;
            foreach (var person in _context.Persons)
            {
                maxPersonSalary = Math.Max(prevPerson, person.Salary);
                prevPerson = person.Salary;
            }
            return await  _context.Persons.Where(x => x.Salary == maxPersonSalary).ToListAsync();
        }*/


        [HttpDelete("{id}")]
        public  ActionResult<Person> DeletePerson(int id)
        {
            var personToRemove = _context.Persons.SingleOrDefault(x => x.Id == id); 

            if (personToRemove != null)
            {
                _context.Persons.Remove(personToRemove);
                _context.SaveChanges();
                return personToRemove;
            }
            else
            {
                return BadRequest("Error");
            }         
        }
    }

   
}
