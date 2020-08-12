using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class RatingDto
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int UserId { get; set; }


        public int VenueId { get; set; }
    }
}
