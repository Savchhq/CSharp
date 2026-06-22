using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegionDto,Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
        }
    }
}