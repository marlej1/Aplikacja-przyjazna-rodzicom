using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BoboTu.Data.Models;
using BoboTu.Web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BoboTu.Web.Controllers
{

    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(
            IConfiguration config,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userDto)
        {
            //userDto.UserName = userDto.UserName.ToLower();

            //if (await _authRepository.UserExists(userDto.UserName))
            //    return BadRequest("Użytkownik już isntnieje");



            var userToCreate = new User()
            {
                UserName = userDto.UserName            
            };

            var result = await  _userManager.CreateAsync(userToCreate, userDto.Password);

            if (result.Succeeded)
            {

                //zwróicić  userToreturn i zwrócić jako  createdAtRoute
                return StatusCode(201);

            }

            return BadRequest(result.Errors);







        }
        [AllowAnonymous]
        [HttpPost("login")]

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {


            var user = await _userManager.FindByNameAsync(userForLoginDto.UserName);
            if(user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);


            if (result.Succeeded)
            {

                // dodać automappera _mapper i zrócić go 
                var appUser = user;

               

              //  var userToReturn = _mapper.Map<UserForListDto>(appUser);

                return Ok(new
                {
                    token = await GenerateJwtToken(appUser),
                    user = appUser
                });
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJwtToken(User appUser)
        {
            var claims = new List<Claim>
           {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };


            var roles = await _userManager.GetRolesAsync(appUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    

       
        [AllowAnonymous]
        [HttpGet("test")]

        public async Task<IActionResult> Test()
        {
            return Ok("Masz uprawnienia");
        }

        [Authorize(Policy ="Admin")]
        [HttpGet("testAdmin")]

        public async Task<IActionResult> testAdmin()
        {
            return Ok("Masz uprawnienia");
        }

        [Authorize(Roles = "Member")]
        [HttpGet("testMember")]

        public async Task<IActionResult> testMember()
        {
            return Ok("testMember");
        }
    }
}