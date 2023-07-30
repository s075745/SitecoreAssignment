using AutoMapper;
using SitecoreAssignmentAPI.Data;
using SitecoreAssignmentAPI.Models.Domain;
using SitecoreAssignmentAPI.Models.DTO;

namespace SitecoreAssignmentAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

        }
    }
}
