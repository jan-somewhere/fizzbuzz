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
        public string Get() {
            FizzbuzzTesting.IntegrationTest();
            return "Integration test ran";
        }

        // GET: api/Fizzbuzz/5
        [HttpGet("{start}", Name = "Get")]
        public string[] Get(int start) {
            CustomLogger.LogInformation("Get FizzBuzz list: " + start);

            string[] list;

            try {
                list = fbm.getList(start);
            } catch (CustomException e) {
                CustomLogger.LogError(e.Message);
                list = new string[] {"error, see log for details: " + CustomLogger.GetLogPath()};
            }

            return list;
        }
    }
}
