using System;
using System.Collections.Generic;
using System.Linq;
using eintech_people_lib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using people_lib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleSource source = new PeopleSource();

        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<IPerson> Get()
        {
            return source.Query.Take(1000);
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public IPerson Get(Guid id)
        {
            return source.Query.FirstOrDefault(person=>person.PersonId == id);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            source.Add(person.Name);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            source.Delete(id);
        }
    }
}
