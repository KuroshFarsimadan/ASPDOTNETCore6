using AutoMapper;

namespace ASPNET6Tutorial.Profiles
{
    public class CityProfile : Profile
    {

        public CityProfile()
        {
            // Source to destination
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
        }
    }
}
