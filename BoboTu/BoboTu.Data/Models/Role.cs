using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BoboTu.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
