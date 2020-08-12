using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string UserName { get; set; }
      [Required]
        public string Password { get; set; }
    }
}
