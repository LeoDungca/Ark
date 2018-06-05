using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ark.Data;
using Ark.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ark.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private ArkDbContext _context;
        public PeopleController(ArkDbContext context)
        {
            this._context = context;
        }

        // GET api/people
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _context.People;
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _context.People.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(value);
                _context.SaveChanges();
            }
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var person = _context.People.Find(id);
                if (person == null)
                {
                    return NotFound();
                }
                
                person.FirstName = value.FirstName;
                person.LastName = value.LastName;

                _context.People.Update(person);
                _context.SaveChanges();

                return new NoContentResult();
            }
            else {
                return BadRequest();
            }

            
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
