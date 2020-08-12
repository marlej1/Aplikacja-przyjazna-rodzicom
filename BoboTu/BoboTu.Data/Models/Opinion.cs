using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoboTu.Data.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

    }
}
