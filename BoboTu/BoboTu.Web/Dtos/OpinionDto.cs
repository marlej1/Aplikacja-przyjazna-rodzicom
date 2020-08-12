using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class OpinionDto
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public int UserId { get; set; }
        public int VenueId { get; set; }
    }
}
