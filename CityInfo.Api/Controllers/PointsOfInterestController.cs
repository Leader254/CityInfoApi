using CityInfo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CityInfo.Api.Controllers
{
    [Route("api/cities/{cityId}/[controller]")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        // get points of interest for a city
        [HttpGet]
        public ActionResult<IEnumerator<PointOfInterestDto>> GetPointsOfInterest(Guid id)
        {
            var cityFound = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityFound == null)
            {
                  return NotFound();
            }
            else
            {
                return Ok(cityFound.PointsOfInterest);
            }
        }
        // get a single point of interest for a city
        [HttpGet("{id}")]
        public ActionResult<PointOfInterestDto> GetSinglePointOfInterest(Guid cityId, Guid id)
        {
            var cityFound = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (cityFound == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = cityFound.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city.pointOfInterestFound);
            }
        }       
    }
}
