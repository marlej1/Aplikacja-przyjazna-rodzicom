using BoboTu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class VenueForCreationDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public string ZipCode { get; set; }
        public VenueType VenueType { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<int> FacilitiesIds { get; set; }
        public string Description { get; set; }
        public RatingDto Rating { get; set; }
        public OpinionDto  Opinion { get; set; }

        public string WebPage { get; set; }
        public string EmailAddress { get; set; }
    }
}
