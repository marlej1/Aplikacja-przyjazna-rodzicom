using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoboTu.Web.Dtos
{
    public class UserForRegisterDto
    { 
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(12, MinimumLength =4, ErrorMessage ="Hasło musi mieć od 4 do 12 znaków")]
        public string Password { get; set; }
    }
}
