using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SitecoreAssignmentAPI.Data;
using SitecoreAssignmentAPI.Models.Domain;
using SitecoreAssignmentAPI.Models.DTO;

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
            // Get Data from the Database - Domain models
            var regionsDomain = dbContext.Regions.ToList();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // Return DTOs
            return Ok(regionsDto);
        }

        // GET Single or get region by Id
        // Get: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id}:Guid")]
        public IActionResult GetById([FromRoute]  Guid id)
        {

            // var region = dbContext.Regions.Find(id);

            // Grt Data from the Database - Domain models

            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);  

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Domain Models to DTOs
            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTOs
            return Ok(regionsDto);

        }

        // POST To Create new region
        // POST: https://localhost:portnumber/api/regions

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            // Map convert DTO to Domain mail
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };

            // Use Domain model to create region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            // Map Domain model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }




    }
}
