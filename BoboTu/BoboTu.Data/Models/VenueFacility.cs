using System;
using System.Collections.Generic;
using System.Text;

namespace BoboTu.Data.Models
{
    public class VenueFacility
    {
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
