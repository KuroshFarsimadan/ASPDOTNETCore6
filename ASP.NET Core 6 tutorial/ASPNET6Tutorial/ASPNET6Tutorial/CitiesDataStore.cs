using ASPNET6Tutorial.Models;

namespace ASPNET6Tutorial
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        // public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            this.Cities = new List<CityDto>() {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.1",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Funny Park",
                            Description = "Don't sit on the benches"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Funny Park2",
                            Description = "Don't sit on the benches2"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New York City 2",
                    Description = "The one with that big park.2",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Funny Park3",
                            Description = "Don't sit on the benches"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Funny Park4",
                            Description = "Don't sit on the benches2"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "New York City 3",
                    Description = "The one with that big park.3",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Funny Park5",
                            Description = "Don't sit on the benches"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Funny Park6",
                            Description = "Don't sit on the benches2"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "New York City 4",
                    Description = "The one with that big park.4",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 7,
                            Name = "Funny Park7",
                            Description = "Don't sit on the benches"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Funny Park8",
                            Description = "Don't sit on the benches2"
                        }
                    }
                }
            };
        }
    }
}
