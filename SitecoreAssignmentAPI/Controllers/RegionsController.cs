using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SitecoreAssignmentAPI.Data;
using SitecoreAssignmentAPI.Models.Domain;

namespace SitecoreAssignmentAPI.Controllers
{
    // Some important code is present which will demostrate the use of dependencey injection.
    // https://localhost:2345/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext dbContext;

        public RegionsController(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get all regions
        // Get: https://localhost:portnumber/api/regions

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

        // GET Singlle or get region by Id
        // Get: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id}:Guid")]
        public IActionResult GetById([FromRoute]  Guid id)
        {

           // var region = dbContext.Regions.Find(id);

            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(region == null)
            {
                return NotFound();
            }
            return Ok(region);

        }


    }
}
