using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoboTu.Data;
using BoboTu.Data.Models;
using BoboTu.Data.Repositories;
using BoboTu.Web.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoboTu.Web.Controllers
{

    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AccountController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userDto)
        {
            userDto.UserName = userDto.UserName.ToLower();

            if (await _authRepository.UserExists(userDto.UserName))
                return BadRequest("Użytkownik już isntnieje");

            var userToCreate = new User()
            {
                UserName = userDto.UserName
            };

            var createdUser = await _authRepository.Register(userToCreate, userDto.Password);

            return StatusCode(201);


        }
    }
}