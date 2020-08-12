using BoboTu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class VenueDto
    {

    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public VenueType VenueType { get; set; }
    public  ICollection<RatingDto> Ratings { get; set; }
    public ICollection<OpinionDto> Opinions { get; set; }
    public List<FacilityDto> Facilities { get; set; }
    public string Description { get; set; }
    public double AverageRating { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public string WebPage { get; set; }
    public string EmailAddress { get; set; }
}
}
