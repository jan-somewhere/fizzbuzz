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
    public class FizzbuzzController : ControllerBase {

        private FizzBuzzModel fbm;

        public FizzbuzzController(FizzBuzzModel _fbm) {
            fbm = _fbm;
        }

        // GET: api/Fizzbuzz
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fizzbuzz/5
        [HttpGet("{start}", Name = "Get")]
        public string[] Get(int start) {
            return fbm.getList(start);
        }
    }
}
