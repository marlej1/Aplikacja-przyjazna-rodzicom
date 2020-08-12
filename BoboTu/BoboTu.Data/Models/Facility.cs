using System;
using System.Collections.Generic;
using System.Text;

namespace BoboTu.Data.Models
{
    public class Facility
    {

        public Facility()
        {
            VenueFacilities = new HashSet<VenueFacility>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VenueFacility> VenueFacilities { get; set; }
    }
}
