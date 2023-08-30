using CityInfo.Api.Models;

namespace CityInfo.Api
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get;  } = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nairobi",
                    Description = "The city under the sun",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Nairobi National Park",
                            Descrition = "The only park in the city in the world"
                        },
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Nairobi National Museum",
                            Descrition = "The museum with the history of Kenya"
                        }
                    }
                },
                new CityDto() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Kampala",
                    Description = "Capital City of Uganda",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Kasubi Tombs",
                            Descrition = "The burial grounds of the Kings of Buganda"
                        },
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Uganda Museum",
                            Descrition = "The museum with the history of Uganda"
                        }
                    }   
                },
                new CityDto() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Mombasa",
                    Description = "The city with the coastline",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Fort Jesus",
                            Descrition = "The fort built by the Portuguese"
                        },
                        new PointOfInterestDto()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Mombasa Marine Park",
                            Descrition = "The marine park with the coral reef"
                        }
                    }       
                }
            };
        }
    }
}
