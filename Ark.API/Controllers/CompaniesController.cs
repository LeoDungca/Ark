using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ark.Data;
using Ark.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ark.API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private ArkDbContext _context;
        public CompaniesController(ArkDbContext context)
        {
            this._context = context;
        }

        // GET api/companies
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _context.Companies;
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            
            return _context.Companies.Find(id);
        }

        // POST api/companies
        [HttpPost]
        public void Post([FromBody]Company value)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Add(value);
                _context.SaveChanges();
            }
        }

        // PUT api/companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Company value)
        {
        }

        // DELETE api/companies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
