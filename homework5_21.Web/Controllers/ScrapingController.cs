using homework5_21.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homework5_21.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapingController : ControllerBase
    {
        [HttpGet]
        [Route("getcoloringbooks")]
        public List<ColoringBook> Get()
        {
            var x = new Scraper();
            return x.Scrape();
        }
    }
}
