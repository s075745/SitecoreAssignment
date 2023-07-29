using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitecoreAssignmentAPI.Models.Domain;

namespace SitecoreAssignmentAPI.Controllers
{
    // https://localhost:2345/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // Get all the regions
        // Get : https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/3293150/pexels-photo-3293150.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=400&h=250&fit=crop&crop=focalpoint"

                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://images.pexels.com/photos/346886/pexels-photo-346886.jpeg?auto=compress&cs=tinysrgb&w=600"

                }
            };
            return Ok(regions);
        }

    }
}
