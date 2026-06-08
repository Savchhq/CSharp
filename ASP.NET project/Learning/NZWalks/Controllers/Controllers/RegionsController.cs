using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Data;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();
            return Ok(regions);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _dbContext.Regions.Find(id);
            //var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(region == null)
            {
                return NotFound();
            }
            else
            {
             return Ok(region);   
            }
        }
        [HttpPost]
        public IActionResult AddRegion()
        {
            //var region;
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRegion()
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRegion()
        {
            return Ok();
        }

    }
}
