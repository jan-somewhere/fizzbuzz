using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fizzbuzz.Controllers
{
    [Route("api/fizzbuzz")]
    [ApiController]
    public class FizzbuzzController : ControllerBase
    {
        // GET: api/Fizzbuzz
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fizzbuzz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fizzbuzz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Fizzbuzz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
