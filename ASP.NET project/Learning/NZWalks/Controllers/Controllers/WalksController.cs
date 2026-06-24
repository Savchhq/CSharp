using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.CustomActionAttribute;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository )
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterName, [FromQuery] string? filterQuery, [FromQuery] string? sortBy,[FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            var walkDomainModel = await walkRepository.GetAllAsync(filterName, filterQuery, sortBy, pageNumber, pageSize);
        
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            walkDomainModel = await walkRepository.AddAsync(walkDomainModel);
            
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = walkDto.Id }, walkDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel =  mapper.Map<Walk>(updateWalkRequestDto);
            
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel); 
            if(walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }

    }
}
