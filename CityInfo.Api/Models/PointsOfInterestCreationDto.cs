using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api.Models
{
    public class PointsOfInterestCreationDto
    {
        [Required(ErrorMessage = "You must provide a name for the point of interest.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must provide a description for the point of interest.")]
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}