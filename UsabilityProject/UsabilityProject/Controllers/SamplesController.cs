using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsabilityProject.Model;
using UsabilityProject.Services.SamplesManager;

namespace UsabilityProject.Controllers
{
    [Authorize(Roles = "health_worker")]
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
        [HttpPost("/samples/last_samples/")]
        public async Task<JsonResult> GetSamples()
        {       
            return  Json(await sm.getSamplesList());
        }
        [HttpPost("/samples/custom_samples/")]
        public async Task<JsonResult> GetCustomSamples(SamplesSelectionModel selection)
        {
            return Json(await sm.getCustomSamplesList(selection));
        }         
    }
}
