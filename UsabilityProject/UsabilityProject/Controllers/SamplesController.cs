using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsabilityProject.Model;
using UsabilityProject.Services.SamplesManager;

namespace UsabilityProject.Controllers
{
    [Route("samples/[controller]")]
    public class SamplesController : Controller
    {
        ISamplesManager sm;
        public SamplesController(ISamplesManager _sm)
        {
            sm = _sm;
        }
        [HttpGet("/createfakesamples")]
        public void CreateFakeSamples()
        {
            sm.CreateFakeSamples();           
        }
        [HttpGet("/samples/last_samples/")]
        public JsonResult GetSamples()
        {       
            return Json(sm.getSamplesList());
        }




        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
