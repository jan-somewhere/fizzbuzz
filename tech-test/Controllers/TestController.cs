using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tech_test.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value3", "value4" };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string[] Get(int id) {
            try {
                return Program.getFizzBuzz(1, id);
            } catch (CustomException e) {
                return new string[] { "value3", "value4" };
            }
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value) {

        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) {

        }
    }
}
