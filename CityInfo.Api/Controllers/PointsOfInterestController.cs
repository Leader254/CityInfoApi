using CityInfo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CityInfo.Api.Controllers
{
    [Route("api/cities/{cityId}/[controller]")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        // get all points of interest
        [HttpGet]
        public ActionResult<IEnumerator<PointOfInterestDto>> GetPointsOfInterest(Guid cityId)
        {
            var cityFound = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (cityFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cityFound.PointsOfInterest);
            }
        }

        // get a single point of interest
        [HttpGet("{id}", Name = "GetPointOfInterest")]
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
                return Ok(pointOfInterestFound);
            }
        }
        // create a new point of interest
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(Guid cityId, PointsOfInterestCreationDto pointOfInterest)
        {
            var cityFound = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);

            if (cityFound == null)
            {
                return NotFound();
            }

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = Guid.NewGuid(),
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            cityFound.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId,
                    id = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }

        // update an existing point of interest
        [HttpPut("{id}")]
        public ActionResult UpdatePointOfInterest(Guid cityId, Guid id, PointOfInterestForUpdateDto pointOfInterestForUpdate)
        {
            // first check if the city exists
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var point = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (point == null)
            {
                return NotFound();
            }
            // update the point of interest
            point.Name = pointOfInterestForUpdate.Name;
            point.Description = pointOfInterestForUpdate.Description;

            return NoContent();
        }

        // delete an existing point of interest
        [HttpDelete("{id}")]
        public ActionResult DeletePointOfInterest(Guid cityId, Guid id)
        {
            // first check if the city exists
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var point = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (point == null)
            {
                return NotFound();
            }
            // delete the point of interest
            city.PointsOfInterest.Remove(point);

            return NoContent();
        }

    }
}
