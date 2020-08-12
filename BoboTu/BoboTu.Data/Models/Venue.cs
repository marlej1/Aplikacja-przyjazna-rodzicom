using System;
using System.Collections.Generic;
using System.Text;

namespace BoboTu.Data.Models
{
    public class Venue
    {
        public Venue()
        {
            Ratings = new HashSet<Rating>();
            Opinions = new HashSet<Opinion>();
            VenueFacilities = new HashSet<VenueFacility>();

        }

        public int Id { get; set; }
        public string Name { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public VenueType VenueType { get; set; }
        public  ICollection<Rating> Ratings { get; set; }
        public  ICollection<Opinion> Opinions { get; set; }
        public  ICollection<VenueFacility> VenueFacilities { get; set; }

        public string Description { get; set; }
        public double AverageRating { get; set; }

        public string WebPage { get; set; }
        public string EmailAddress { get; set; }
    }
}
