using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BoboTu.Data.Models
{
    public class User :IdentityUser<int>
    {

        public User()
        {
            Ratings = new HashSet<Rating>();
            Opinions = new HashSet<Opinion>();
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Opinion> Opinions { get; set; }
    }
}
