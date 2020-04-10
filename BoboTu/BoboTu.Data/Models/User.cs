using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoboTu.Data.Models
{
    public class User :IdentityUser<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
