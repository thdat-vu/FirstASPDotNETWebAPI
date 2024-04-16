using DatvtFirstWebAPI.Data;
using DatvtFirstWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatvtFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            var persons = await _context.Persons.ToListAsync();
            return Ok(persons); 
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if(person == null)
            {
                //return NotFound(); //status code: 404
                return BadRequest("Person not found"); //status code: 400 + message
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            var personFromDb = await _context.Persons.FindAsync(person.Id);
            if (personFromDb == null)
            {
                return BadRequest("Person not found");
            }
            personFromDb.Name = person.Name;
            personFromDb.FirstName = person.FirstName;
            personFromDb.LastName = person.LastName;
            personFromDb.Place = person.Place;  
            //_context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var personFromDb = await _context.Persons.FindAsync(id);
            if (personFromDb == null)
            {
                return BadRequest("Person not found");
            }
            
            _context.Remove(personFromDb);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }
    }
}
