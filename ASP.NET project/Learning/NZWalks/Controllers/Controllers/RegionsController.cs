using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Auckland_Region_location_in_New_Zealand.svg/250px-Auckland_Region_location_in_New_Zealand.svg.png"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Wellington_Region_location_in_New_Zealand.svg/250px-Wellington_Region_location_in_New_Zealand.svg.png"
                }
            };
            return Ok(regions);
        }
        [HttpPost]
        public IActionResult AddRegion()
        {
            
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
